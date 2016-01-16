using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Business.Contracts;
using Business.Entities;
using Core.Common.Secure;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class CustomerOperationService : ICustomerOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.BoostAccount> _boostAccountRepository;
        private readonly IRepository<Data.Entities.PurchaseTicket> _purchaseTicketRepository;
        private readonly IRepository<Data.Entities.Customer> _customerRepository;
        private readonly IRepository<Data.Entities.Ticket> _ticketRepository;
        private readonly IRepository<Data.Entities.Discount> _discountRepository;

        private Data.Entities.Customer _actualLoggedCustomer;
        private PurchaseTicket _purchaseTicket;

        public CustomerOperationService(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.BoostAccount> boostAccountRepository, 
            IRepository<Data.Entities.PurchaseTicket> purchaseTicketRepository, 
            IRepository<Data.Entities.Customer> customerRepository,
            IRepository<Data.Entities.Ticket> ticketRepository,
            IRepository<Data.Entities.Discount> discountRepository)
        {
            _boostAccountRepository = boostAccountRepository;
            _purchaseTicketRepository = purchaseTicketRepository;
            _customerRepository = customerRepository;
            _ticketRepository = ticketRepository;
            _discountRepository = discountRepository;

            _unitOfWork = unitOfWork; 
        }

        public IEnumerable<BoostAccount> GetAllBoostAccount(string userName, string password)
        {
            FindCustomer(userName, password);

            _boostAccountRepository.EnrollUnitOfWork(_unitOfWork);
            
            var customerPurchaseTickets = _boostAccountRepository
                .FindBy(p => p.Customer?.Email == _actualLoggedCustomer.Email, "Customer");

            return ConvertToReturn(customerPurchaseTickets);
        }

        public IEnumerable<PurchaseTicket> GetAllPurchaseTicket(string userName, string password)
        {
            FindCustomer(userName, password);

            _purchaseTicketRepository.EnrollUnitOfWork(_unitOfWork);

            var customerPurchaseTickets = _purchaseTicketRepository
                .FindBy(p => p.Customer?.Email == _actualLoggedCustomer.Email, "Customer");

            return ConvertToReturn(customerPurchaseTickets);
        }

        public IEnumerable<PurchaseTicket> GetActivePurchaseTicket(string userName, string password, string deviceId)
        {
            FindCustomer(userName, password);

            _purchaseTicketRepository.EnrollUnitOfWork(_unitOfWork);

            //TODO ACTIVE TICKET

            var customerPurchaseTickets = _purchaseTicketRepository
                .FindBy(p => p.Customer?.Email == _actualLoggedCustomer.Email && p.DateOfPurchase < DateTime.Now, "Customer");

            return ConvertToReturn(customerPurchaseTickets);
        }

        public void UpdateCustomerEmail(string userName, string password, string email)
        {
            FindCustomer(userName, password);

            _customerRepository.EnrollUnitOfWork(_unitOfWork);

            try
            {         
                _actualLoggedCustomer.Email = email;

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        public void UpdateCustomerPassword(string userName, string password, string newPassword)
        {
            FindCustomer(userName, password);

            _customerRepository.EnrollUnitOfWork(_unitOfWork);
            
            try
            {           
                if (!PasswordHash.ValidatePassword(password, _actualLoggedCustomer.HashPassword))
                {
                    throw new FaultException("Incorrect old password.");
                }

                _actualLoggedCustomer.HashPassword = PasswordHash.CreateHash(newPassword);

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        public void CreateNewBoostAccount(string userName, string password, string code)
        {
            FindCustomer(userName, password);

            _boostAccountRepository.EnrollUnitOfWork(_unitOfWork);

            var boostAccount = _boostAccountRepository
                .FindBy(b => b.Code == code, "Customer").FirstOrDefault();

            if (boostAccount == null)
            {
                throw new FaultException("Wrong code!");
            }
            if (boostAccount.CustomerId != null)
            {
                throw new FaultException("That code was used!");
            }
                
            boostAccount.CustomerId = _actualLoggedCustomer.Id;

            boostAccount.DateOfBoost = DateTime.UtcNow;

            _unitOfWork.Commit();

            ChangeAccountBallance(boostAccount.Amount);
        }

        public void CreateNewPurchaseTicket(string userName, string password, PurchaseTicket purchaseTicket, int howManyTickets = 1)
        {
            FindCustomer(userName, password);

            _purchaseTicket = purchaseTicket;

            if (purchaseTicket.DeviceId == null &&
                (purchaseTicket.FirstNameTicketOwner == null || purchaseTicket.LastNameTicketOwner == null))
            {
                throw new FaultException("Ticket need deviceId or first and last name.");
            }

            if (howManyTickets < 1)
            {
                throw new FaultException("Wrong tickets amount.");
            }

            var fullPrice = CalculateFullPrice(howManyTickets);

            if (_actualLoggedCustomer.AccountBallance < fullPrice)
            {
                throw new FaultException("You are too poor to buy that tickets.");
            }

            PayForTickets(fullPrice);

            AssignTicketToAccount(howManyTickets);
        }

        private void FindCustomer(string userName, string password)
        {
            _customerRepository.EnrollUnitOfWork(_unitOfWork);

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new FaultException("Username and passwrod required.");
            }

            var customer = _customerRepository
                  .FindBy(c => c.Email == userName && PasswordHash.ValidatePassword(password, c.HashPassword));

            if (!customer.Any())
            {
                throw new FaultException("Wrong username or password.");
            }

            if (customer.First().IsDeleted)
            {
                throw new FaultException("That user is blocked. Contact with support.");
            }

            _actualLoggedCustomer = customer.First();
        }

        private IEnumerable<BoostAccount> ConvertToReturn(IEnumerable<Data.Entities.BoostAccount> boostAccounts)
        {
            return AutoMapper.Mapper.Map<IEnumerable<BoostAccount>>(boostAccounts);
        }

        private IEnumerable<PurchaseTicket> ConvertToReturn(IEnumerable<Data.Entities.PurchaseTicket> purchaseTickets)
        {
            return AutoMapper.Mapper.Map<IEnumerable<PurchaseTicket>>(purchaseTickets);
        }

        private void AssignTicketToAccount(int howManyTickets)
        {
            _purchaseTicketRepository.EnrollUnitOfWork(_unitOfWork);

            _purchaseTicket.CustomerId = _actualLoggedCustomer.Id;

            _purchaseTicket.DateOfPurchase = DateTime.UtcNow;

            for (int i = 0; i < howManyTickets; i++)
            {
                _purchaseTicketRepository.Add(AutoMapper.Mapper.Map<Data.Entities.PurchaseTicket>(_purchaseTicket));
            }

            _unitOfWork.Commit();
        }

        private void PayForTickets(double price)
        {
            _customerRepository.EnrollUnitOfWork(_unitOfWork);

            _actualLoggedCustomer.AccountBallance -= price;

            _unitOfWork.Commit();
        }

        private void ChangeAccountBallance(double amount)
        {
            _customerRepository.EnrollUnitOfWork(_unitOfWork);

            _actualLoggedCustomer.AccountBallance += amount;

            _unitOfWork.Commit();
        }

        private double CalculateFullPrice(int howManyTickets)
        {
            return CalculateOneTicket()*howManyTickets;
        }

        private double CalculateOneTicket()
        {
            return GetTicketPrice() - GetTicketPrice()*GetDiscountPercent();
        }

        private double GetDiscountPercent()
        {
            _discountRepository.EnrollUnitOfWork(_unitOfWork);

            var  discountPrice =
                    _discountRepository.FindBy(d => d.Id == _purchaseTicket.DiscountId && !d.IsDeleted).First().Percent;

            return discountPrice/100;
        }

        private double GetTicketPrice()
        {
            _ticketRepository.EnrollUnitOfWork(_unitOfWork);

            var ticketPrice = _ticketRepository.FindBy(t => t.Id == _purchaseTicket.TicketId && !t.IsDeleted).First().Price;

            return ticketPrice;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    internal class SeedPurchaseTicket : ISeedMethod
    {
        private readonly DataContext _dataContext;

        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Ticket> _ticketRepository;

        private readonly List<PurchaseTicket> _purchaseTickets = new List<PurchaseTicket>();

        public SeedPurchaseTicket(DataContext dataContext, IRepository<Customer> customerRepository, IRepository<Discount> discountRepository, IRepository<Ticket> ticketRepository)
        {
            _dataContext = dataContext;
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
            _ticketRepository = ticketRepository;
        }

        public void FillTable()
        {
            for (int i = 0; i < 50; i++)
            {
                _purchaseTickets.Add(new PurchaseTicket() { Id = i + 1, DateOfPurchase = DateTime.Now });
            }

            AddCustomers();
            AddDiscounts();
            AddTickets();

            foreach (var purchaseTicket in _purchaseTickets)
            {
                _dataContext.Set<PurchaseTicket>().AddOrUpdate(purchaseTicket);
            }                         

            _dataContext.SaveChanges();
        }

        private void AddCustomers()
        {
            _customerRepository.EnrollUnitOfWork(_dataContext);
            var customerList = _customerRepository.FindAll().ToList();

            for (int i = 0; i < _purchaseTickets.Count; i++)
            {
                var purchaseTicket = _purchaseTickets[i];

                purchaseTicket.Customer = customerList[i % customerList.Count];               
            }
        }

        private void AddDiscounts()
        {
            _discountRepository.EnrollUnitOfWork(_dataContext);
            var discountList = _discountRepository.FindAll().ToList();

            for (int i = 0; i < _purchaseTickets.Count; i++)
            {
                var purchaseTicket = _purchaseTickets[i];

                if (i % 5 != 0)
                {
                    purchaseTicket.Discount = discountList[i % discountList.Count];
                }
            }
        }

        private void AddTickets()
        {
            _ticketRepository.EnrollUnitOfWork(_dataContext);
            var ticketList = _ticketRepository.FindAll().ToList();

            for (int i = 0; i < _purchaseTickets.Count; i++)
            {
                var purchaseTicket = _purchaseTickets[i];
                purchaseTicket.Ticket = ticketList[i%ticketList.Count];

                if (purchaseTicket.Ticket.TicketType.Name == "Season")
                {
                    purchaseTicket.FirstNameTicketOwner = "SampleFirstName" + i;
                    purchaseTicket.LastNameTicketOwner = "SampleLastName" + i;
                    purchaseTicket.DocumentIdentificationNumber = "SmapleIdentity" + i;
                }
                else
                {
                    purchaseTicket.DeviceId = "SampleDeviceId" + i;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Contracts;
using Business.Entities;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class PurchaseTicketManager : IPurchaseTicketSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.PurchaseTicket> _purchaseTicketRepository;

        public PurchaseTicketManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.PurchaseTicket> purchaseTicketRepository)
        {
            _purchaseTicketRepository = purchaseTicketRepository;
            _unitOfWork = unitOfWork;

            _purchaseTicketRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<PurchaseTicket> GetAll()
        {
            var result = _purchaseTicketRepository.FindAll().AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetToDate(DateTime dateTime)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.DateOfPurchase < dateTime)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetAfterDate(DateTime dateTime)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.DateOfPurchase > dateTime)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetByFirstName(string firstName)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.FirstNameTicketOwner == firstName)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetByLastName(string lastName)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.LastNameTicketOwner == lastName)
                .AsEnumerable();

            return ConvertToReturn(result); ;
        }

        public IEnumerable<PurchaseTicket> GetFromDevice(string deviceId)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.DeviceId == deviceId)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public PurchaseTicket GetById(int id)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetByCustomerId(int customerId)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.CustomerId == customerId)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<PurchaseTicket> GetFromDate(DateTime dateTime)
        {
            var result = _purchaseTicketRepository
                .FindBy(p => p.DateOfPurchase.Date == dateTime.Date)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        private IEnumerable<PurchaseTicket> ConvertToReturn(IEnumerable<Data.Entities.PurchaseTicket> purchaseTickets)
        {
            return AutoMapper.Mapper.Map<IEnumerable<PurchaseTicket>>(purchaseTickets);
        }

        private PurchaseTicket ConvertToReturn(Data.Entities.PurchaseTicket purchaseTicket)
        {
            return AutoMapper.Mapper.Map<PurchaseTicket>(purchaseTicket);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Business.Contracts;
using Business.Entities;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class TicketManager : ITicketService, ITicketSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Ticket> _ticketRepository;

        public TicketManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;

            _ticketRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<Ticket> GetAll()
        {
            var result = _ticketRepository
                .FindBy(t => !t.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Ticket> GetWherePriceMoreThan(double price)
        {
            var result = _ticketRepository
                .FindBy(t => t.Price > price && !t.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Ticket> GetWherePriceLessThan(double price)
        {
            var result = _ticketRepository
                .FindBy(t => t.Price < price && !t.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Ticket> GetWhereTicketTypeId(int ticketTypeId)
        {
            var result = _ticketRepository
                .FindBy(t => t.TicketTypeId == ticketTypeId && !t.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Ticket GetById(int id)
        {
            var result = _ticketRepository
                .FindBy(t => t.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public Ticket GetByName(string name)
        {
            var result = _ticketRepository
                .FindBy(t => t.Name == name)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public IEnumerable<Ticket> GetAllWithDeleted()
        {
            var result = _ticketRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(Ticket ticket)
        {
            try
            {
                var mapTicket = AutoMapper.Mapper.Map
                    <Data.Entities.Ticket>(ticket);

                _ticketRepository.Add(mapTicket);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Ticket ticket)
        {
            try
            {
                var mapTicket = AutoMapper.Mapper.Map
                    <Data.Entities.Ticket>(ticket);

                var actualTicket = _ticketRepository
                    .FindBy(t => t.Id == mapTicket.Id)
                    .First();

                actualTicket.Name = mapTicket.Name;
                actualTicket.Price = mapTicket.Price;
                actualTicket.Duration = mapTicket.Duration;
                actualTicket.TicketTypeId = mapTicket.TicketTypeId;
                actualTicket.IsDeleted = mapTicket.IsDeleted;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var actualTicket = _ticketRepository
                    .FindBy(d => d.Id == id)
                    .First();

                if (actualTicket.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualTicket.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {                
                throw new FaultException(exception.Message);
            }
        }

        public void UndeleteById(int id)
        {
            try
            {
                var actualTicket = _ticketRepository
                    .FindBy(d => d.Id == id)
                    .First();

                if (!actualTicket.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualTicket.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Ticket> ConvertToReturn(IEnumerable<Data.Entities.Ticket> tickets)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Ticket>>(tickets);
        }

        private Ticket ConvertToReturn(Data.Entities.Ticket ticket)
        {
            return AutoMapper.Mapper.Map<Ticket>(ticket);
        }
    }
}

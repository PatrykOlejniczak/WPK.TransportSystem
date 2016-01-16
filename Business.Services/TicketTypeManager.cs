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
    public class TicketTypeManager : ITicketTypeService, ITicketTypeSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.TicketType> _ticketTypeRepository;

        public TicketTypeManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.TicketType> ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
            _unitOfWork = unitOfWork;

            _ticketTypeRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<TicketType> GetAll()
        {
            var result = _ticketTypeRepository.FindBy(t => !t.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public TicketType GetById(int id)
        {
            var result = _ticketTypeRepository
                .FindBy(t => t.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public TicketType GetByName(string name)
        {
            var result = _ticketTypeRepository
                .FindBy(t => t.Name == name)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public void Create(TicketType ticketType)
        {
            try
            {
                var mapTicketType = AutoMapper.Mapper.Map
                    <Data.Entities.TicketType>(ticketType);

                _ticketTypeRepository.Add(mapTicketType);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {                
                throw new FaultException(exception.Message);
            }            
        }

        public void Update(TicketType ticketType)
        {
            try
            {
                var mapTicketType = AutoMapper.Mapper.Map
                    <Data.Entities.TicketType>(ticketType);

                var actualTicketType = _ticketTypeRepository
                    .FindBy(t => t.Id == mapTicketType.Id)
                    .First();

                actualTicketType.Name = mapTicketType.Name;
                actualTicketType.Description = mapTicketType.Description;
                actualTicketType.IsDeleted = mapTicketType.IsDeleted;

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
                var actualTicketType = _ticketTypeRepository
                    .FindBy(t => t.Id == id)
                    .First();

                actualTicketType.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {                
                throw new FaultException(exception.Message);
            }            
        }

        private IEnumerable<TicketType> ConvertToReturn(IEnumerable<Data.Entities.TicketType> ticketTypes)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TicketType>>(ticketTypes);
        }

        private TicketType ConvertToReturn(Data.Entities.TicketType ticketType)
        {
            return AutoMapper.Mapper.Map<TicketType>(ticketType);
        }
    }
}
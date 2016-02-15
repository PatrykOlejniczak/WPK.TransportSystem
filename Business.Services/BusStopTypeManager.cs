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
    public class BusStopTypeManager : IBusStopTypeService,
        IBusStopTypeSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.BusStopType> _busStopTypeRepository;

        public BusStopTypeManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.BusStopType> busStopTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _busStopTypeRepository = busStopTypeRepository;

            _busStopTypeRepository.EnrollUnitOfWork(_unitOfWork);
        } 

        public IEnumerable<BusStopType> GetAll()
        {
            var result = _busStopTypeRepository
                .FindBy(b => b.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public BusStopType GetById(int id)
        {
            var result = _busStopTypeRepository
                .FindBy(b => b.Id == id)
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<BusStopType> GetAllWithDeleted()
        {
            var result = _busStopTypeRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(BusStopType busStopType)
        {
            try
            {
                var mapBusStopType = AutoMapper.Mapper.Map
                    <Data.Entities.BusStopType>(busStopType);

                _busStopTypeRepository.Add(mapBusStopType);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(BusStopType busStopType)
        {
            try
            {
                var actualBusStopType = _busStopTypeRepository
                    .FindBy(b => b.Id == busStopType.Id)
                    .First();

                actualBusStopType.Name = busStopType.Name;

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
                var actualBusStopType = _busStopTypeRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (actualBusStopType.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualBusStopType.IsDeleted = true;

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
                var actualBusStopType = _busStopTypeRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (!actualBusStopType.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualBusStopType.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<BusStopType> ConvertToReturn(IEnumerable<Data.Entities.BusStopType> busStopTypes)
        {
            return AutoMapper.Mapper.Map<IEnumerable<BusStopType>>(busStopTypes);
        }

        private BusStopType ConvertToReturn(Data.Entities.BusStopType busStopType)
        {
            return AutoMapper.Mapper.Map<BusStopType>(busStopType);
        }
    }
}
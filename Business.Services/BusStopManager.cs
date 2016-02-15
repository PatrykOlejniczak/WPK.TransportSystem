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
    public class BusStopManager : IBusStopService,
        IBusStopSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.BusStop> _busStopRepository;

        public BusStopManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.BusStop> busStopRepository)
        {
            _unitOfWork = unitOfWork;
            _busStopRepository = busStopRepository;

            _busStopRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<BusStop> GetAll()
        {
            var result = _busStopRepository
                .FindBy(b => b.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public BusStop GetById(int id)
        {
            var result = _busStopRepository
                .FindBy(b => b.Id == id)
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<BusStop> GetAllWithDeleted()
        {
            var result = _busStopRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(BusStop busStop)
        {
            try
            {
                var mapBusStop = AutoMapper.Mapper.Map
                    <Data.Entities.BusStop>(busStop);

                _busStopRepository.Add(mapBusStop);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(BusStop busStop)
        {
            try
            {
                var actualBusStop = _busStopRepository
                    .FindBy(b => b.Id == busStop.Id)
                    .First();

                actualBusStop.Name = busStop.Name;
                actualBusStop.Street = busStop.Street;
                actualBusStop.BusStopTypeId = busStop.BusStopTypeId;

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
                var actualBusStop = _busStopRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (actualBusStop.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualBusStop.IsDeleted = true;

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
                var actualBusStop = _busStopRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (!actualBusStop.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualBusStop.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<BusStop> ConvertToReturn(IEnumerable<Data.Entities.BusStop> busStopTypes)
        {
            return AutoMapper.Mapper.Map<IEnumerable<BusStop>>(busStopTypes);
        }

        private BusStop ConvertToReturn(Data.Entities.BusStop busStopType)
        {
            return AutoMapper.Mapper.Map<BusStop>(busStopType);
        }
    }
}
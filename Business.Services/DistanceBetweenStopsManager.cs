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
    public class DistanceBetweenStopsManager 
        : IDistanceBetweenStopsService, IDistanceBetweenStopsSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.DistanceBetweenStops> _distanceBetweenStopsRepository;

        public DistanceBetweenStopsManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.DistanceBetweenStops> distanceBetweenStopsRepository)
        {
            _unitOfWork = unitOfWork;
            _distanceBetweenStopsRepository = distanceBetweenStopsRepository;

            _distanceBetweenStopsRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<DistanceBetweenStops> GetAll()
        {
            var result = _distanceBetweenStopsRepository
                .FindBy(d => d.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public DistanceBetweenStops GetById(int id)
        {
            var result = _distanceBetweenStopsRepository
                .FindBy(d => d.Id == id)
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<DistanceBetweenStops> GetAllWithDeleted()
        {
            var result = _distanceBetweenStopsRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(DistanceBetweenStops distanceBetweenStops)
        {
            try
            {
                var mapDistanceBetweenStops = AutoMapper.Mapper.Map
                    <Data.Entities.DistanceBetweenStops>(distanceBetweenStops);

                _distanceBetweenStopsRepository.Add(mapDistanceBetweenStops);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(DistanceBetweenStops distanceBetweenStops)
        {
            try
            {
                var actualDistanceBetweenStops = _distanceBetweenStopsRepository
                    .FindBy(b => b.Id == distanceBetweenStops.Id)
                    .First();

                actualDistanceBetweenStops.DistanceInKilometers = distanceBetweenStops.DistanceInKilometers;
                actualDistanceBetweenStops.FirstBusStopId = distanceBetweenStops.FirstBusStopId;
                actualDistanceBetweenStops.SecondBusStopId = distanceBetweenStops.SecondBusStopId;
                actualDistanceBetweenStops.TravelTime = distanceBetweenStops.TravelTime;

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
                var actualDistanceBetweenStops = _distanceBetweenStopsRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (actualDistanceBetweenStops.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualDistanceBetweenStops.IsDeleted = true;

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
                var actualDistanceBetweenStops = _distanceBetweenStopsRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (!actualDistanceBetweenStops.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualDistanceBetweenStops.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<DistanceBetweenStops> ConvertToReturn(IEnumerable<Data.Entities.DistanceBetweenStops> busStopTypes)
        {
            return AutoMapper.Mapper.Map<IEnumerable<DistanceBetweenStops>>(busStopTypes);
        }

        private DistanceBetweenStops ConvertToReturn(Data.Entities.DistanceBetweenStops busStopType)
        {
            return AutoMapper.Mapper.Map<DistanceBetweenStops>(busStopType);
        }
    }
}
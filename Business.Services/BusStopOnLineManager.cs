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
    public class BusStopOnLineManager : IBusStopOnLineService,
        IBusStopOnLineSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.BusStopOnLine> _busStopOnLineRepository;

        public BusStopOnLineManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.BusStopOnLine> busStopOnLineRepository)
        {
            _unitOfWork = unitOfWork;
            _busStopOnLineRepository = busStopOnLineRepository;

            _busStopOnLineRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<BusStopOnLine> GetAll()
        {
            var result = _busStopOnLineRepository
                .FindBy(b => b.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public BusStopOnLine GetById(int id)
        {
            var result = _busStopOnLineRepository
                .FindBy(b => b.Id == id)
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<BusStopOnLine> GetAllWithDeleted()
        {
            var result = _busStopOnLineRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(BusStopOnLine busStopOnLine)
        {
            try
            {
                var mapBusStopOnLine = AutoMapper.Mapper.Map
                    <Data.Entities.BusStopOnLine>(busStopOnLine);

                _busStopOnLineRepository.Add(mapBusStopOnLine);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(BusStopOnLine busStopOnLine)
        {
            try
            {
                var actualBusStopOnLine = _busStopOnLineRepository
                    .FindBy(b => b.Id == busStopOnLine.Id)
                    .First();

                actualBusStopOnLine.BusStopId = busStopOnLine.BusStopId;
                actualBusStopOnLine.Direction = busStopOnLine.Direction;
                actualBusStopOnLine.LineId = busStopOnLine.LineId;
                actualBusStopOnLine.NumberStopOnLine = busStopOnLine.NumberStopOnLine;

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
                var actualBusStopOnLine = _busStopOnLineRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (actualBusStopOnLine.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualBusStopOnLine.IsDeleted = true;

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
                var actualBusStopOnLine = _busStopOnLineRepository
                    .FindBy(b => b.Id == id)
                    .First();

                if (!actualBusStopOnLine.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualBusStopOnLine.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<BusStopOnLine> ConvertToReturn(IEnumerable<Data.Entities.BusStopOnLine> busStopTypes)
        {
            return AutoMapper.Mapper.Map<IEnumerable<BusStopOnLine>>(busStopTypes);
        }

        private BusStopOnLine ConvertToReturn(Data.Entities.BusStopOnLine busStopType)
        {
            return AutoMapper.Mapper.Map<BusStopOnLine>(busStopType);
        }
    }
}
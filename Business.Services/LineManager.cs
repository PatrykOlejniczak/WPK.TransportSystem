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
    public class LineManager : ILineService,
        ILineSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Line> _lineRepository;

        public LineManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.Line> lineRepository)
        {
            _unitOfWork = unitOfWork;
            _lineRepository = lineRepository;

            _lineRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<Line> GetAll()
        {
            var result = _lineRepository
                .FindBy(line => line.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Line GetById(int id)
        {
            var result = _lineRepository
                .FindBy(line => line.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<Line> GetAllWithDeleted()
        {
            var result = _lineRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(Line line)
        {
            try
            {
                var mapLine = AutoMapper.Mapper.Map
                    <Data.Entities.Line>(line);

                _lineRepository.Add(mapLine);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Line line)
        {
            try
            {
                var mapLine = AutoMapper.Mapper.Map
                    <Data.Entities.Line>(line);

                var actualLine = _lineRepository
                    .FindBy(li => li.Id == mapLine.Id)
                    .First();

                actualLine.Name = mapLine.Name;

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
                var actualLine = _lineRepository
                    .FindBy(li => li.Id == id)
                    .First();

                if (actualLine.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualLine.IsDeleted = true;

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
                var actualLine = _lineRepository
                    .FindBy(li => li.Id == id)
                    .First();

                if (!actualLine.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualLine.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Line> ConvertToReturn(IEnumerable<Data.Entities.Line> lines)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Line>>(lines);
        }

        private Line ConvertToReturn(Data.Entities.Line line)
        {
            return AutoMapper.Mapper.Map<Line>(line);
        }
    }
}
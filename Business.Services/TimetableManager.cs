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
    public class TimetableManager : ITimetableService,
        ITimetableSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Timetable> _timetrableRepository;

        public TimetableManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.Timetable> timetrableRepository)
        {
            _unitOfWork = unitOfWork;
            _timetrableRepository = timetrableRepository;

            _timetrableRepository.EnrollUnitOfWork(_unitOfWork);
        }
         
        public IEnumerable<Timetable> GetAll()
        {
            var result = _timetrableRepository
                .FindBy(t => t.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Timetable GetById(int id)
        {
            var result = _timetrableRepository
                .FindBy(t => t.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public void Create(Timetable timetable)
        {
            try
            {
                var mapTimetable = AutoMapper.Mapper.Map
                    <Data.Entities.Timetable>(timetable);

                _timetrableRepository.Add(mapTimetable);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Timetable timetable)
        {
            try
            {
                var mapTimetable = AutoMapper.Mapper.Map
                    <Data.Entities.Timetable>(timetable);

                var actualTimetable = _timetrableRepository
                    .FindBy(t => t.Id == mapTimetable.Id)
                    .First();

                actualTimetable.BusStopOnLineId = mapTimetable.BusStopOnLineId;
                actualTimetable.DepartureTime = mapTimetable.DepartureTime;

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
                var actualTimetable = _timetrableRepository
                    .FindBy(t => t.Id == id)
                    .AsEnumerable()
                    .First();

                actualTimetable.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Timetable> ConvertToReturn(IEnumerable<Data.Entities.Timetable> timetables)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Timetable>>(timetables);
        }

        private Timetable ConvertToReturn(Data.Entities.Timetable timetable)
        {
            return AutoMapper.Mapper.Map<Timetable>(timetable);
        } 
    }
}
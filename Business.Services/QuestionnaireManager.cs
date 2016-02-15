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
    public class QuestionnaireManager : IQuestionnaireService,
        IQuestionnaireSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Questionnaire> _questionnainerRepository;

        public QuestionnaireManager(IUnitOfWork unitOfWork, 
            IRepository<Data.Entities.Questionnaire> questionnainerRepository)
        {
            _unitOfWork = unitOfWork;
            _questionnainerRepository = questionnainerRepository;

            _questionnainerRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<Questionnaire> GetAll()
        {
            var result = _questionnainerRepository
                .FindBy(t => t.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Questionnaire GetById(int id)
        {
            var result = _questionnainerRepository
                .FindBy(t => t.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public IEnumerable<Questionnaire> GetAllWithDeleted()
        {
            var result = _questionnainerRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Questionnaire> GetByEmployeeId(int employeeId)
        {
            var result = _questionnainerRepository
                .FindBy(t => t.EmployeeId == employeeId)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(Questionnaire questionnaire)
        {
            try
            {
                var mapQuestionnaire = AutoMapper.Mapper.Map
                    <Data.Entities.Questionnaire>(questionnaire);

                _questionnainerRepository.Add(mapQuestionnaire);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Questionnaire questionnaire)
        {
            try
            {
                var mapQuestionnaire= AutoMapper.Mapper.Map
                    <Data.Entities.Questionnaire>(questionnaire);

                var actualQuestionnaire = _questionnainerRepository
                    .FindBy(t => t.Id == mapQuestionnaire.Id)
                    .First();

                actualQuestionnaire.Question = mapQuestionnaire.Question;
                actualQuestionnaire.EndDate = mapQuestionnaire.EndDate;
                actualQuestionnaire.EmployeeId = mapQuestionnaire.EmployeeId;
                actualQuestionnaire.StartDate = mapQuestionnaire.StartDate;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void DelteById(int id)
        {
            try
            {
                var actualQuestionnaire = _questionnainerRepository
                    .FindBy(d => d.Id == id)
                    .First();

                if (actualQuestionnaire.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualQuestionnaire.IsDeleted = true;

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
                var actualQuestionnaire = _questionnainerRepository
                    .FindBy(d => d.Id == id)
                    .First();

                if (!actualQuestionnaire.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualQuestionnaire.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Questionnaire> ConvertToReturn(IEnumerable<Data.Entities.Questionnaire> tickets)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Questionnaire>>(tickets);
        }

        private Questionnaire ConvertToReturn(Data.Entities.Questionnaire ticket)
        {
            return AutoMapper.Mapper.Map<Questionnaire>(ticket);
        }
    }
}
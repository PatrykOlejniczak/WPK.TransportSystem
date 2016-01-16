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
    public class AnswerOptionManager : IAnswerOptionService,
        IAnswerOptionSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.AnswerOption> _answerOptionRepository;

        public AnswerOptionManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.AnswerOption> answerOptionRepository)
        {
            _unitOfWork = unitOfWork;
            _answerOptionRepository = answerOptionRepository;

            _answerOptionRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<AnswerOption> GetAll()
        {
            var result = _answerOptionRepository.FindBy(t => !t.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<AnswerOption> GetByQuestionnaireId(int questionnaireId)
        {
            var result = _answerOptionRepository.FindBy(t => !t.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public AnswerOption GetById(int id)
        {
            var result = _answerOptionRepository
                .FindBy(t => t.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public void Create(AnswerOption answerOption)
        {
            try
            {
                var mapAnswerOption = AutoMapper.Mapper.Map
                    <Data.Entities.AnswerOption>(answerOption);

                _answerOptionRepository.Add(mapAnswerOption);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(AnswerOption answerOption)
        {
            try
            {
                var mapAnswer = AutoMapper.Mapper.Map
                    <Data.Entities.AnswerOption>(answerOption);

                var actualAnswer = _answerOptionRepository
                    .FindBy(a => a.Id == mapAnswer.Id)
                    .First();

                actualAnswer.NumberOfVotes = mapAnswer.NumberOfVotes;
                actualAnswer.Option = mapAnswer.Option;
                actualAnswer.QuestionnaireId = mapAnswer.QuestionnaireId;

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
                var actualAnswerOption = _answerOptionRepository
                    .FindBy(d => d.Id == id)
                    .AsEnumerable();

                actualAnswerOption.First().IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<AnswerOption> ConvertToReturn(IEnumerable<Data.Entities.AnswerOption> answerOptions)
        {
            return AutoMapper.Mapper.Map<IEnumerable<AnswerOption>>(answerOptions);
        }

        private AnswerOption ConvertToReturn(Data.Entities.AnswerOption answerOption)
        {
            return AutoMapper.Mapper.Map<AnswerOption>(answerOption);
        }
    }
}
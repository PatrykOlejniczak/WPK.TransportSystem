using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    public class SeedAnswerOption : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<Questionnaire> _questionnaireRepository;

        private readonly  List<AnswerOption> _answers = new List<AnswerOption>()
        {
            new AnswerOption() { Id = 1, Option = "Answer Option 1", NumberOfVotes = 1, IsDeleted = false },
            new AnswerOption() { Id = 2, Option = "Answer Option 2", NumberOfVotes = 2, IsDeleted = false },
            new AnswerOption() { Id = 3, Option = "Answer Option 3", NumberOfVotes = 3, IsDeleted = false },
            new AnswerOption() { Id = 4, Option = "Answer Option 4", NumberOfVotes = 4, IsDeleted = false },
            new AnswerOption() { Id = 5, Option = "Answer Option 5", NumberOfVotes = 5, IsDeleted = false },
            new AnswerOption() { Id = 6, Option = "Answer Option 6", NumberOfVotes = 6, IsDeleted = false },
            new AnswerOption() { Id = 7, Option = "Answer Option 7", NumberOfVotes = 7, IsDeleted = false }
        };

        public SeedAnswerOption(DataContext dataContext, IRepository<Questionnaire> questionnaireRepository)
        {
            _dataContext = dataContext;
            _questionnaireRepository = questionnaireRepository;
        }
        public void FillTable()
        {
            _questionnaireRepository.EnrollUnitOfWork(_dataContext);

            var questionnaire = _questionnaireRepository.FindAll().ToList();

            for (int i = 0; i < _answers.Count; i++)
            {
                var answer = _answers[i];
                answer.Questionnaire = questionnaire[i % questionnaire.Count()];

                _dataContext.Set<AnswerOption>().AddOrUpdate(answer);
            }

            _dataContext.SaveChanges();
        }
    }
}
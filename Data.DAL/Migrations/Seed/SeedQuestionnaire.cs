using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    public class SeedQuestionnaire : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<Employee> _employeeRepository;

        private readonly List<Questionnaire> _questionnaires = new List<Questionnaire>()
        {
            new Questionnaire() { Id = 1, Question = "Sample Question 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1.0), IsDeleted = false },
            new Questionnaire() { Id = 2, Question = "Sample Question 2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1.0), IsDeleted = false },
            new Questionnaire() { Id = 3, Question = "Sample Question 3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1.0), IsDeleted = false }
        };

        public SeedQuestionnaire(DataContext dataContext, IRepository<Employee> employeeRepository)
        {
            _dataContext = dataContext;
            _employeeRepository = employeeRepository;
        }

        public void FillTable()
        {
            _employeeRepository.EnrollUnitOfWork(_dataContext);

            var employee = _employeeRepository.FindAll().First();

            for (int i = 0; i < _questionnaires.Count; i++)
            {
                var questionnaires = _questionnaires[i];
                questionnaires.Employee = employee;

                _dataContext.Set<Questionnaire>().AddOrUpdate(questionnaires);
            }

            _dataContext.SaveChanges();
        }

    }
}
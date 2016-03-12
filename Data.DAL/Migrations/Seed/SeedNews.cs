using System;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Data.Core.Migrations.Seed
{
    public class SeedNews : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<Employee> _employeeRepository;
         
        private readonly List<News> _newses = new List<News>()
        {
            new News() { Id = 1, Content = "Some content html 0.", Title = "Some title html 0.", CreateDate = DateTime.Now, IsDeleted = false },
            new News() { Id = 2, Content = "Some content html 1.", Title = "Some title html 1.", CreateDate = DateTime.Now, IsDeleted = false },
            new News() { Id = 3, Content = "Some content html 2.", Title = "Some title html 2.", CreateDate = DateTime.Now, IsDeleted = false }
        };

        public SeedNews(DataContext dataContext, IRepository<Employee> employeeRepository)
        {
            _dataContext = dataContext;
            _employeeRepository = employeeRepository;
        }

        public void FillTable()
        {
            _employeeRepository.EnrollUnitOfWork(_dataContext);

            var employee = _employeeRepository.FindAll().First();

            for (int i = 0; i < _newses.Count; i++)
            {
                var news = _newses[i];
                news.Employee = employee;

                _dataContext.Set<News>().AddOrUpdate(news);
            }

            _dataContext.SaveChanges();
        }
    }
}
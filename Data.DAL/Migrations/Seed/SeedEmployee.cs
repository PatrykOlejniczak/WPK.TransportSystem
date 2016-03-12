using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    public class SeedEmployee : ISeedMethod
    {
        private readonly DataContext _dataContext;

        private readonly List<Employee> _employeesList = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "FirstName1", LastName ="LastName1", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null },
            new Employee() { Id = 2, FirstName = "FirstName2", LastName ="LastName2", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null },
            new Employee() { Id = 3, FirstName = "FirstName3", LastName ="LastName3", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null },
            new Employee() { Id = 4, FirstName = "FirstName4", LastName ="LastName4", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null },
            new Employee() { Id = 5, FirstName = "FirstName5", LastName ="LastName5", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null },
            new Employee() { Id = 6, FirstName = "FirstName6", LastName ="LastName6", StartDate = DateTime.Now, AreaCode = null, City = null, Country = null, EndDate = null, PostalCode = null, Province = null, SecondName = null, Street = null }
        };

        public SeedEmployee(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void FillTable()
        {
            foreach (Employee employee in _employeesList)
            {
                _dataContext.Set<Employee>().AddOrUpdate(employee);
            }
            _dataContext.SaveChanges();

            //Run this when you have some error on update-database
            //try
            //{
            //    _dataContext.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();
            //        }
            //    }

            //    throw new DbEntityValidationException(
            //        "Entity Validation Failed - errors follow:\n" +
            //        sb.ToString(), ex
            //    ); // Add the original exception as the innerException
            //}
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Core.Common.Secure;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    public class SeedUserAccount : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<Employee> _employeeRepository;

        private readonly List<UserAccount> _userAccount = new List<UserAccount>()
        {
            new UserAccount() { Id = 1, Login = "UserAccount1", HashPassword = PasswordHash.CreateHash("password1"), IsDeleted = false },
            new UserAccount() { Id = 2, Login = "UserAccount2", HashPassword = PasswordHash.CreateHash("password2"), IsDeleted = false }
        };

        public SeedUserAccount(DataContext dataContext, IRepository<Employee> employeeRepository)
        {
            _dataContext = dataContext;
            _employeeRepository = employeeRepository;
        }

        public void FillTable()
        {
            _employeeRepository.EnrollUnitOfWork(_dataContext);

            var employee = _employeeRepository.FindAll().ToList();

            for (int i = 0; i < _userAccount.Count; i++)
            {
                var userAccount = _userAccount[i];
                userAccount.Employee = employee[i];

                _dataContext.Set<UserAccount>().AddOrUpdate(userAccount);
            }

            _dataContext.SaveChanges();
        }
    }
}
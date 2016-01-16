using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    internal class SeedBoostAccount : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<Customer> _customerRepository; 

        private readonly List<BoostAccount> _boostAccounts = new List<BoostAccount>()
         {
             new BoostAccount() { Id = 1,  Code = "98789876", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 1 },
             new BoostAccount() { Id = 2,  Code = "42341552", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 1 },
             new BoostAccount() { Id = 3,  Code = "54325235", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 2 },
             new BoostAccount() { Id = 4,  Code = "13412344", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 2 },
             new BoostAccount() { Id = 5,  Code = "54325452", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 3 },
             new BoostAccount() { Id = 6,  Code = "85878785", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 3 },
             new BoostAccount() { Id = 7,  Code = "75634535", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 4 },
             new BoostAccount() { Id = 8,  Code = "65365436", Amount = 10.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 5 },
             new BoostAccount() { Id = 9,  Code = "41324356", Amount = 20.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 6 },
             new BoostAccount() { Id = 10, Code = "78798925", Amount = 20.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 7 },
             new BoostAccount() { Id = 11, Code = "63654633", Amount = 20.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = new DateTime(2016, 1, 1, 0, 0, 0), CustomerId = 8 },
             new BoostAccount() { Id = 12, Code = "52345565", Amount = 20.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = null, CustomerId = null },
             new BoostAccount() { Id = 13, Code = "212563E5", Amount = 30.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = null, CustomerId = null },
             new BoostAccount() { Id = 14, Code = "54467853", Amount = 30.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = null, CustomerId = null },
             new BoostAccount() { Id = 15, Code = "42355476", Amount = 30.00, GeneratedDateTime = new DateTime(2016, 1, 1, 0, 0, 0), DateOfBoost = null, CustomerId = null }
         };

        public SeedBoostAccount(DataContext dataContext, IRepository<Customer> customerRepository)
        {
            _dataContext = dataContext;
            _customerRepository = customerRepository;
        }

        public void FillTable()
        {
            _customerRepository.EnrollUnitOfWork(_dataContext);

            var customerList = _customerRepository.FindAll().ToList();

            for (int i = 0; i < _boostAccounts.Count - 4; i++)
            {
                var boostAccount = _boostAccounts[i];
                boostAccount.Customer = customerList[i % customerList.Count];

                _dataContext.Set<BoostAccount>().AddOrUpdate(boostAccount);
            }

            _dataContext.SaveChanges();
        }
        
    }
}
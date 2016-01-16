using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Core.Common.Secure;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    internal class SeedCustomer : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly List<Customer> _customers = new List<Customer>()
        {
            new Customer() { Id = 1, Email = "jan.kowalski@onet.eu",      HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 80.0   },
            new Customer() { Id = 2, Email = "basia.kowalska@onet.eu",    HashPassword = PasswordHash.CreateHash("kowalska"), IsDeleted = false, AccountBallance = 80.0   },
            new Customer() { Id = 3, Email = "czesio.kowalski@onet.eu",   HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 90.30  },
            new Customer() { Id = 4, Email = "bogus.kowalski@onet.eu",    HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 380.30 },
            new Customer() { Id = 5, Email = "norbert.kowalski@onet.eu",  HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 280.40 },
            new Customer() { Id = 6, Email = "zenon.kowalski@onet.eu",    HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 10.80  },
            new Customer() { Id = 7, Email = "krzysztof.kowalski@onet.eu",HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 5.20   },
            new Customer() { Id = 8, Email = "maciej.kowalski@onet.eu",   HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 1.30   },
            new Customer() { Id = 9, Email = "tomek.kowalski@onet.eu",    HashPassword = PasswordHash.CreateHash("kowalski"), IsDeleted = false, AccountBallance = 14.10  },
            new Customer() { Id = 10,Email = "judyta.kowalska@onet.eu",   HashPassword = PasswordHash.CreateHash("kowalska"), IsDeleted = false, AccountBallance = 50.14  }
        };

        public SeedCustomer(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void FillTable()
        {
            foreach (var customer in _customers)
            {
                _dataContext.Set<Customer>().AddOrUpdate(customer);
            }
            _dataContext.SaveChanges();
        }

    }
}
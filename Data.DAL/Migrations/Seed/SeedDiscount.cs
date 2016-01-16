using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    internal class SeedDiscount : ISeedMethod
    {
        private readonly DataContext _dataContext;

        private readonly List<Discount> _discounts = new List<Discount>()
        {
            new Discount() { Id = 1, Name = "Student",  Description = "Discount for students under 26 year old.",   Percent = 51.00, IsDeleted = false },
            new Discount() { Id = 2, Name = "Kid",      Description = "Discount for kinds under 10 year old.",      Percent = 80.0,  IsDeleted = false },
            new Discount() { Id = 3, Name = "Disabled", Description = "Discount for disabled people.",              Percent = 90.0,  IsDeleted = false }
        };

        public SeedDiscount(DataContext dataContex)
        {
            _dataContext = dataContex;
        }

        public void FillTable()
        {
            foreach (var discount in _discounts)
            {
                _dataContext.Set<Discount>().AddOrUpdate(discount);
            }
            _dataContext.SaveChanges();
        }

    }
}
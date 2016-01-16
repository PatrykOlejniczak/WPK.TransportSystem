using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Data.Core.Migrations.Seed;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        private DataContext _dataContext;

        private readonly IRepository<Discount> _discountRepository = new Repository<Discount>();
        private readonly IRepository<TicketType> _ticketTypeRepository = new Repository<TicketType>();
        private readonly IRepository<Ticket> _ticketRepository = new Repository<Ticket>();
        private readonly IRepository<News> _newsRepository = new Repository<News>();
        private readonly IRepository<Employee> _employeeRepository = new Repository<Employee>();
        private readonly IRepository<Questionnaire> _questionnaireRepository = new Repository<Questionnaire>();
        private readonly IRepository<Customer> _customerRepository = new Repository<Customer>();

        private readonly List<ISeedMethod> _seedEntities = new List<ISeedMethod>();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext dataContext)
        {
            _dataContext = dataContext;

            CreateSeeds();

            foreach (var seedMethod in _seedEntities)
            {
                seedMethod.FillTable();
            }
        }

        private void CreateSeeds()
        {
            _seedEntities.Add(new SeedDiscount(_dataContext));
            _seedEntities.Add(new SeedTicketType(_dataContext));
            _seedEntities.Add(new SeedCustomer(_dataContext));
            _seedEntities.Add(new SeedTicket(_dataContext, _ticketTypeRepository));
            _seedEntities.Add(new SeedBoostAccount(_dataContext, _customerRepository));
            _seedEntities.Add(new SeedPurchaseTicket(_dataContext, _customerRepository, _discountRepository, _ticketRepository));
            _seedEntities.Add(new SeedEmployee(_dataContext));
            _seedEntities.Add(new SeedNews(_dataContext, _employeeRepository));
            _seedEntities.Add(new SeedUserAccount(_dataContext, _employeeRepository));
            _seedEntities.Add(new SeedQuestionnaire(_dataContext, _employeeRepository));
            _seedEntities.Add(new SeedAnswerOption(_dataContext, _questionnaireRepository));
        }


    }
}

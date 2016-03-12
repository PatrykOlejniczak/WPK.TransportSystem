using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Core.UnitOfWork.Configuration;
using Data.Entities;

namespace Data.Core.UnitOfWork
{
    public class DataContext : DataContextBase
    {
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<BoostAccount> BooostAccounts { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<BusStopOnLine> BusStopOnLines { get; set; }
        public DbSet<BusStopType> BusStopTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DistanceBetweenStops> DistanceBetweenStopses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PurchaseTicket> PurchaseTickets { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AnswerOptionConfiguration());
            modelBuilder.Configurations.Add(new BoostAccountConfiguration());
            modelBuilder.Configurations.Add(new BusStopConfiguration());
            modelBuilder.Configurations.Add(new BusStopOnLineConfiguration());
            modelBuilder.Configurations.Add(new BusStopTypeConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new DiscountConfiguration());
            modelBuilder.Configurations.Add(new DistanceBetweenStopsConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new LineConfiguration());
            modelBuilder.Configurations.Add(new NewsConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
            modelBuilder.Configurations.Add(new PurchaseTicketConfiguration());
            modelBuilder.Configurations.Add(new QuestionnaireConfiguration());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new TicketTypeConfiguration());
            modelBuilder.Configurations.Add(new TimetableConfiguration());
            modelBuilder.Configurations.Add(new UserAccountConfiguration());

        }
    }
}
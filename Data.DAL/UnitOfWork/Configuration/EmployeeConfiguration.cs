using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class EmployeeConfiguration
        : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.FirstName).IsRequired();
            Property(e => e.LastName).IsRequired();
            Property(e => e.StartDate).IsRequired();

            Property(e => e.AreaCode).IsOptional();
            Property(e => e.City).IsOptional();
            Property(e => e.Country).IsOptional();
            Property(e => e.EndDate).IsOptional();
            Property(e => e.PostalCode).IsOptional();
            Property(e => e.Province).IsOptional();
            Property(e => e.SecondName).IsOptional();
            Property(e => e.Street).IsOptional();

            HasMany(e => e.Newses)
                .WithRequired(n => n.Employee)
                .HasForeignKey(n => n.EmployeeId);

            HasMany(e => e.Questionnaires)
                .WithRequired(q => q.Employee)
                .HasForeignKey(q => q.EmployeeId);

            HasMany(e => e.UserAccounts)
                .WithRequired(u => u.Employee)
                .HasForeignKey(u => u.EmployeeId);
        }
    }
}
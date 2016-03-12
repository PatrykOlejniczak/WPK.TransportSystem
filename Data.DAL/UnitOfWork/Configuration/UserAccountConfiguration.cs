using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class UserAccountConfiguration
        : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Login).IsRequired();
            Property(u => u.HashPassword).IsRequired();
            Property(u => u.IsDeleted).IsRequired();

            HasRequired(u => u.Employee)
                .WithMany(e => e.UserAccounts)
                .HasForeignKey(u => u.EmployeeId);
        }
    }
}
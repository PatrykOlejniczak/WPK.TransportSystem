using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.AccountBallance).IsRequired();
            Property(c => c.Email).IsRequired();
            Property(c => c.HashPassword).IsRequired();
            Property(c => c.IsDeleted).IsRequired();

            HasMany(c => c.PurchaseTickets)
                .WithRequired(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            HasMany(c => c.BoostAccounts)
                .WithOptional(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
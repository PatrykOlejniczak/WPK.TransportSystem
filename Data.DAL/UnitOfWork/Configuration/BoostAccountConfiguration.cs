using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class BoostAccountConfiguration : EntityTypeConfiguration<BoostAccount>
    {
        public BoostAccountConfiguration()
        {
            HasKey(b => b.Id);

            Property(b => b.Amount).IsRequired();
            Property(b => b.Code).IsRequired();
            Property(b => b.GeneratedDateTime).IsRequired();

            Property(b => b.DateOfBoost).IsOptional();

            HasOptional(b => b.Customer)
                .WithMany(c => c.BoostAccounts)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
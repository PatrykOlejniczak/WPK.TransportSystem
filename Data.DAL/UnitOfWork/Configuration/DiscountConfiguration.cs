using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class DiscountConfiguration : EntityTypeConfiguration<Discount>
    {
        public DiscountConfiguration()
        {
            HasKey(d => d.Id);

            Property(d => d.Name).IsRequired();
            Property(d => d.Percent).IsRequired();
            Property(d => d.IsDeleted).IsRequired();

            Property(d => d.Description).IsOptional();

            HasMany(d => d.PurchaseTickets)
                .WithOptional(p => p.Discount)
                .HasForeignKey(p => p.DiscountId);
        }
    }
}
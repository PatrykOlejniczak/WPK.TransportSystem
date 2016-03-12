using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class BusStopTypeConfiguration
        : EntityTypeConfiguration<BusStopType>
    {
        public BusStopTypeConfiguration()
        {
            HasKey(b => b.Id);

            Property(b => b.Name).IsRequired();
            Property(b => b.IsDeleted).IsRequired();

            HasMany(b => b.BusStops)
                .WithRequired(t => t.BusStopType)
                .HasForeignKey(t => t.BusStopTypeId);
        }
    }
}
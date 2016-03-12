using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class BusStopConfiguration
        : EntityTypeConfiguration<BusStop>
    {
        public BusStopConfiguration()
        {
            HasKey(b => b.Id);

            Property(b => b.Name).IsRequired();
            Property(b => b.Street).IsRequired();
            Property(b => b.IsDeleted).IsRequired();

            HasRequired(b => b.BusStopType)
                .WithMany(s => s.BusStops)
                .HasForeignKey(b => b.BusStopTypeId);

            HasMany(b => b.BusStopOnLines)
                .WithRequired(line => line.BusStop)
                .HasForeignKey(b => b.BusStopId);

            HasMany(b => b.FirstBusStopInDistanceBetweenStopses)
                .WithRequired(d => d.FirstBusStop)
                .HasForeignKey(b => b.FirstBusStopId);

            HasMany(b => b.SecondBusStopInDistanceBetweenStopses)
                .WithRequired(d => d.SecondBusStop)
                .HasForeignKey(b => b.SecondBusStopId);
        }
    }
}
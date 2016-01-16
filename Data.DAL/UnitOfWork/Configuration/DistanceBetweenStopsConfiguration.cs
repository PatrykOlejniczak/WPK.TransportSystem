using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class DistanceBetweenStopsConfiguration 
        : EntityTypeConfiguration<DistanceBetweenStops>
    {
        public DistanceBetweenStopsConfiguration()
        {
            HasKey(d => d.Id);

            Property(d => d.DistanceInKilometers).IsRequired();
            Property(d => d.TravelTime).IsRequired();
            Property(d => d.IsDeleted).IsRequired();

            HasRequired(d => d.FirstBusStop)
                .WithMany(b => b.FirstBusStopInDistanceBetweenStopses)
                .HasForeignKey(d => d.FirstBusStopId);

            HasRequired(d => d.SecondBusStop)
                .WithMany(b => b.SecondBusStopInDistanceBetweenStopses)
                .HasForeignKey(d => d.SecondBusStopId);
        }
    }
}
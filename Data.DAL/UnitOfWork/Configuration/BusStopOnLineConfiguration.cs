using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class BusStopOnLineConfiguration
        : EntityTypeConfiguration<BusStopOnLine>
    {
        public BusStopOnLineConfiguration()
        {
            HasKey(b => b.Id);

            Property(b => b.Direction).IsRequired();
            Property(b => b.NumberStopOnLine).IsRequired();
            Property(b => b.IsDeleted).IsRequired();

            HasRequired(b => b.BusStop)
                .WithMany(s => s.BusStopOnLines)
                .HasForeignKey(b => b.BusStopId);

            HasRequired(b => b.Line)
                .WithMany(line => line.BusStopOnLines)
                .HasForeignKey(b => b.LineId);
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class TimetableConfiguration
        : EntityTypeConfiguration<Timetable>
    {
        public TimetableConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.DepartureTime).IsRequired();
            Property(t => t.IsDeleted).IsRequired();

            HasRequired(t => t.BusStopOnLine)
                .WithMany(b => b.Timetables)
                .HasForeignKey(t => t.BusStopOnLineId);
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class LineConfiguration
        : EntityTypeConfiguration<Line>
    {
        public LineConfiguration()
        {
            HasKey(line => line.Id);

            Property(line => line.Name).IsRequired();
            Property(line => line.IsDeleted).IsRequired();

            HasMany(line => line.BusStopOnLines)
                .WithRequired(b => b.Line)
                .HasForeignKey(b => b.LineId);
        }
    }
}
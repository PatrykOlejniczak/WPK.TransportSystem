using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class TicketTypeConfiguration : EntityTypeConfiguration<TicketType>
    {
        public TicketTypeConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name).IsRequired();
            Property(t => t.IsDeleted).IsRequired();

            Property(t => t.Description).IsOptional();

            HasMany(t => t.Tickets)
                .WithRequired(ticket => ticket.TicketType)
                .HasForeignKey(ticket => ticket.TicketTypeId);
        }
    }
}
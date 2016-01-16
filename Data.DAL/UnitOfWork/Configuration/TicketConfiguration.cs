using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Name).IsRequired();
            Property(t => t.Price).IsRequired();
            Property(t => t.IsDeleted).IsRequired();

            HasMany(t => t.PurchaseTickets)
                .WithRequired(p => p.Ticket)
                .HasForeignKey(t => t.TicketId);

            HasRequired(t => t.TicketType)
                .WithMany(type => type.Tickets)
                .HasForeignKey(type => type.TicketTypeId);
        }
    }
}
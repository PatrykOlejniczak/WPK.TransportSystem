using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class PurchaseTicketConfiguration 
        : EntityTypeConfiguration<PurchaseTicket>
    {
        public PurchaseTicketConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.DateOfPurchase).IsRequired();

            Property(p => p.DeviceId).IsOptional();
            Property(p => p.FirstNameTicketOwner).IsOptional();
            Property(p => p.LastNameTicketOwner).IsOptional();
            Property(p => p.DocumentIdentificationNumber).IsOptional();

            HasRequired(p => p.Customer)
                .WithMany(c => c.PurchaseTickets)
                .HasForeignKey(c => c.CustomerId);

            HasRequired(p => p.Ticket)
                .WithMany(t => t.PurchaseTickets)
                .HasForeignKey(t => t.TicketId);

            HasOptional(p => p.Discount)
                .WithMany(d => d.PurchaseTickets)
                .HasForeignKey(d => d.DiscountId);
        } 
    }
}
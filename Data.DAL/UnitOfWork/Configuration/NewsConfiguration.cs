using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class NewsConfiguration
        : EntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        {
            HasKey(n => n.Id);

            Property(n => n.Title).IsRequired();
            Property(n => n.Content).IsRequired();
            Property(n => n.CreateDate).IsRequired();
            Property(n => n.IsDeleted).IsRequired();

            HasRequired(n => n.Employee)
                .WithMany(e => e.Newses)
                .HasForeignKey(n => n.EmployeeId);

            HasMany(n => n.Photos)
                .WithRequired(p => p.News)
                .HasForeignKey(p => p.NewsId);
        }
    }
}
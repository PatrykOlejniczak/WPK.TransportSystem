using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class PhotoConfiguration
        : EntityTypeConfiguration<Photo>
    {
        public PhotoConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired();
            Property(p => p.File).IsRequired();
            Property(p => p.IsDeleted).IsRequired();

            HasRequired(p => p.News)
                .WithMany(n => n.Photos)
                .HasForeignKey(p => p.NewsId);
        }
    }
}
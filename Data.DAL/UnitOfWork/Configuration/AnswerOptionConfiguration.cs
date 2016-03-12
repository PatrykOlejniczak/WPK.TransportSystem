using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class AnswerOptionConfiguration
        : EntityTypeConfiguration<AnswerOption>
    {
        public AnswerOptionConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.Option).IsRequired();
            Property(a => a.NumberOfVotes).IsRequired();
            Property(a => a.IsDeleted).IsRequired();

            HasRequired(a => a.Questionnaire)
                .WithMany(q => q.AnswerOptions)
                .HasForeignKey(a => a.QuestionnaireId);
        }
    }
}
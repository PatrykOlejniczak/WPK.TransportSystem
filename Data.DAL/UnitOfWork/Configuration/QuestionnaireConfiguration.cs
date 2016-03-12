using System.Data.Entity.ModelConfiguration;
using Data.Entities;

namespace Data.Core.UnitOfWork.Configuration
{
    public class QuestionnaireConfiguration
        : EntityTypeConfiguration<Questionnaire>
    {
        public QuestionnaireConfiguration()
        {
            HasKey(q => q.Id);

            Property(q => q.Question).IsRequired();
            Property(q => q.EndDate).IsRequired();
            Property(q => q.StartDate).IsOptional();
            Property(q => q.IsDeleted).IsRequired();

            HasMany(q => q.AnswerOptions)
                .WithRequired(a => a.Questionnaire)
                .HasForeignKey(q => q.QuestionnaireId);

            HasRequired(q => q.Employee)
                .WithMany(e => e.Questionnaires)
                .HasForeignKey(q => q.EmployeeId);
        }
    }
}
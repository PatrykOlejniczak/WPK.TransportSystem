namespace Data.Entities
{
    public class AnswerOption
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public int NumberOfVotes { get; set; }
        public bool IsDeleted { get; set; }
        public int QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }        
    }
}
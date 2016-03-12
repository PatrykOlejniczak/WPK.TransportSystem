using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AnswerOption> AnswerOptions { get; private set; }

        public Questionnaire()
        {
            AnswerOptions = new HashSet<AnswerOption>();
        }
    }
}
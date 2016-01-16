using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AreaCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } 

        public virtual ICollection<UserAccount> UserAccounts { get; private set; }
        public virtual ICollection<News> Newses { get; private set; }
        public virtual ICollection<Questionnaire> Questionnaires { get; private set; }

        public Employee()
        {
            Newses = new HashSet<News>();
            Questionnaires = new HashSet<Questionnaire>();
            UserAccounts = new HashSet<UserAccount>();
        }
    }
}
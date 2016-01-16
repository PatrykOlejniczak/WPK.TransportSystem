using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Photo> Photos { get; private set; }

        public News()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
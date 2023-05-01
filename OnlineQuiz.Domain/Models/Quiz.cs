
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQuiz.Domain
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}

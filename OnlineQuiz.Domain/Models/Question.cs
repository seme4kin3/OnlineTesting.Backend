using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineQuiz.Domain
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        [ForeignKey("QuizId")]
        public Guid QuizId { get; set; }
        
        [JsonIgnore]
        public Quiz? Quiz { get; set; }
        public virtual ICollection<Answer>? Answers { get; set; }
    }
}

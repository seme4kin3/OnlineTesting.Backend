using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineQuiz.Domain
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("QuestionId")]
        public Guid QuestionId { get; set; }
        [JsonIgnore]
        public Question? Question { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineQuiz.Domain
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public Guid IdQuiz { get; set; }
        [JsonIgnore]
        public virtual Quiz Quiz { get; set; }
        public string? TotalScore { get; set; }
    }
}

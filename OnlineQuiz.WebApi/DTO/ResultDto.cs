namespace OnlineQuiz.WebApi.DTO
{
    public class ResultDto
    {
        public Guid IdUser { get; set; }
        public Guid IdQuiz { get; set; }
        public string? TotalScore { get; set; }
    }
}

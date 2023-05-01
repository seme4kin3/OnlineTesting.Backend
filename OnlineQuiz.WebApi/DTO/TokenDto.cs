namespace OnlineQuiz.WebApi.DTO
{
    public class TokenDto
    {
        public Guid UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? Message { get; set; }
        public string? AccessToken { get; set; }
    }
}

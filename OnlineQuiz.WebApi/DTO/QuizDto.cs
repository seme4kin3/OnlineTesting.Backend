
namespace OnlineQuiz.WebApi.DTO
{
    public class QuizDto
    {
        
        public string Title { get; set; }
        public string Description { get; set; }

        public List<QuestionDto> Questions { get; set; }
    }
}

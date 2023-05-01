namespace OnlineQuiz.WebApi.DTO
{
    public class QuestionDto
    {
        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}

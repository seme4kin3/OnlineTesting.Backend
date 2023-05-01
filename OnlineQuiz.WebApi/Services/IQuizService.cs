using OnlineQuiz.Domain;

namespace OnlineQuiz.WebApi.Services
{
    public interface IQuizService
    {
        public Task<IEnumerable<Quiz>> ListQuiz();

        public Task<Quiz> FindQuiz(Guid id);

        public Task<Quiz> CreateQuiz(Quiz quiz);
        //public Task UpdateQuiz(Quiz quiz);
        public Task DeleteQuiz(Guid id);

        public Task<Question> CreateQuestion(Question question);

        public Task<Answer> CreateAnswer(Answer answer);
    }
}

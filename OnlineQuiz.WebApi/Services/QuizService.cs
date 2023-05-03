using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain;
using OnlineQuiz.Persistance;

namespace OnlineQuiz.WebApi.Services
{
    public class QuizService : IQuizService
    {
        private readonly DataContext _context;
        private readonly ILogger<QuizService> _logger;

        public QuizService(DataContext context, ILogger<QuizService> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public async Task<Answer> CreateAnswer(Answer answer)
        {
            await _context.AddAsync(answer);
            return answer;
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            await _context.AddAsync(question);
            return question;
        }

        public async Task<Quiz> CreateQuiz(Quiz quiz)
        {
            await _context.Quizs.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return await FindQuiz(quiz.Id);
        }

        public async Task DeleteQuiz(Guid id)
        {
            var remove = await _context.Quizs.FindAsync(id);
            _context.Quizs.Remove(remove);
            await _context.SaveChangesAsync();
        }

        public async Task<Quiz> FindQuiz(Guid id)
        {
            var data = await _context.Quizs
                .Include(q => q.Questions)
                    .ThenInclude(t => t.Answers)
                    .ToListAsync();

            var quiz = data.FirstOrDefault(x => x.Id == id);
            return quiz;
        }

        public async Task<IEnumerable<Quiz>> ListQuiz()
        {
            var quiz = await _context.Quizs.ToListAsync();
            return quiz;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Domain;
using OnlineQuiz.WebApi.DTO;
using OnlineQuiz.WebApi.Services;


namespace OnlineQuiz.WebApi.Controllers
{
    public class QuizController : BaseController
    {
        private readonly IQuizService _db;

        public QuizController(IQuizService db)
        {
            this._db = db;
        }

        [HttpGet, Authorize]
        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await _db.ListQuiz();
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var quiz = await _db.FindQuiz(id);
            if (quiz == default) return NotFound();
            return Ok(quiz);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post(QuizDto dto)
        {
            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                DateCreated = DateTime.Now
            };

            foreach (var q in dto.Questions)
            {
                var question = new Question
                {
                    Id = Guid.NewGuid(),
                    Text = q.Text,
                    QuizId = quiz.Id
                };

                await _db.CreateQuestion(question);

                foreach (var a in q.Answers)
                {
                    var answer = new Answer
                    {
                        Id = Guid.NewGuid(),
                        Text = a.Text,
                        QuestionId = question.Id,
                        IsCorrect = a.IsCorrect
                    };

                    await _db.CreateAnswer(answer);
                }
            }

            await _db.CreateQuiz(quiz);
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quiz = _db.FindQuiz(id);
            if (quiz == null) return NotFound();
            await _db.DeleteQuiz(id);
            return NoContent();
        }
    }
}

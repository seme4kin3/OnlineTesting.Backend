using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.Domain;
using OnlineQuiz.WebApi.DTO;
using OnlineQuiz.WebApi.Services;


namespace OnlineQuiz.WebApi.Controllers
{
    public class ResultController : BaseController
    {
        private readonly IResultService _db;

        public ResultController(IResultService db)
        {
            _db = db;
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetResult(Guid id)
        {
            var result = await _db.GetByUserId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateResult(ResultDto resultDto)
        {
            var result = new Result()
            {
                Id = Guid.NewGuid(),
                IdUser = resultDto.IdUser,
                IdQuiz = resultDto.IdQuiz,
                TotalScore = resultDto.TotalScore
            };

            await _db.PostResult(result);

            return Ok(result);
        }
    }
}

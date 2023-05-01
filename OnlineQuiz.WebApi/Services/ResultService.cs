using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain;
using OnlineQuiz.Persistance;

namespace OnlineQuiz.WebApi.Services
{
    public class ResultService : IResultService
    {
        private readonly DataContext _context;
        private readonly ILogger<ResultService> _logger;

        public ResultService(DataContext context, ILogger<ResultService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<dynamic> GetByUserId(Guid id)
        {
            var result = _context.Results.Where(x => x.IdUser == id);
            var data = await result.Select(x => new
            {
                x.Quiz.Title,
                x.Quiz.Description,
                x.TotalScore,
            }).ToListAsync();

            return data;
        }

        public async Task<Result> PostResult(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}

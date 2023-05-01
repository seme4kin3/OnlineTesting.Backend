using OnlineQuiz.Domain;

namespace OnlineQuiz.WebApi.Services
{
    public interface IResultService
    {
        public Task<Result> PostResult(Result result);
        public Task<dynamic> GetByUserId(Guid id);
    }
}

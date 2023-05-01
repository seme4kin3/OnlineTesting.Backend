using OnlineQuiz.Domain;

namespace OnlineQuiz.WebApi.Services
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<User> FindUser(string email);
    }
}

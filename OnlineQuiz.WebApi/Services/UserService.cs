using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Domain;
using OnlineQuiz.Persistance;

namespace OnlineQuiz.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(DataContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> FindUser(string email)
        {
            var data = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return data;
        }
    }
}

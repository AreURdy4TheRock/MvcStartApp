using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext _blogContext;
        public BlogRepository(BlogContext context)
        {
            _blogContext = context;
        }
        public async Task AddUser(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _blogContext.Entry(user);
            if (entry.State == EntityState.Detached)
                await _blogContext.Users.AddAsync(user);

            // Сохранение изенений
            await _blogContext.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            // Получим всех активных пользователей
            return await _blogContext.Users.ToArrayAsync();
        }

    }
}

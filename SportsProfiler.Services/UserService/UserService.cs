using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SportsProfiler.DAL.DAL;
using SportsProfiler.Models.Models;

namespace SportsProfiler.Services.UserService
{
    public class UserService : GenericRepository<User, SportsProfilerDataContext>, IUserService
    {
        public async void CreateAsync(User user)
        {
            await AddAsync(user);
        }

        public async Task<User> FindAsync(Guid id)
        {
            return await FindAsync(x => x.UserId == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await FindAsync(x => x.Email == email);
        }

        public new async Task<List<User>> GetAllAsync()
        {
            return await GetAllAsync();
        }

        public new async Task<int> DeleteAsync(User user)
        {
            return await DeleteAsync(user);
        }
    }
}
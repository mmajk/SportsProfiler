using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsProfiler.DAL.DAL;
using SportsProfiler.Models.Models;

namespace SportsProfiler.Services.UserService
{
    public interface IUserService : IGenericRepository<User>
    {
        void CreateAsync(User user);

        Task<User> FindAsync(Guid id);

        Task<User> GetByEmailAsync(string email);

        new Task<List<User>> GetAllAsync();

        new Task<int> DeleteAsync(User user);
        
        
    }
}
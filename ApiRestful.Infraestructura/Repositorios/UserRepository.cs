using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
using ApiRestful.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Infraestructura.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiRestfulContext _dbContext;
        public UserRepository(ApiRestfulContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await _dbContext.Users.ToListAsync();
        }
 
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);  
        }

        public Task InsertAsync(User post)
        {
             throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User post)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

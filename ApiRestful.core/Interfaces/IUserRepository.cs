using ApiRestful.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task InsertAsync(User post);
        Task<bool> UpdateAsync(User post);
        Task<bool> DeleteAsync(int id);
    }
}

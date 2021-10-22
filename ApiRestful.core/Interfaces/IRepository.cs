using ApiRestful.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}

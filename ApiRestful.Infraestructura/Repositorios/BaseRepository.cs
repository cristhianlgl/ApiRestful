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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApiRestfulContext _dbContext;
        protected readonly DbSet<T> _entities;
        public BaseRepository(ApiRestfulContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
        }
    }
}

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
        private readonly DbSet<T> _entities;
        public BaseRepository(ApiRestfulContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _entities.Update(entity);
            var resul = await _dbContext.SaveChangesAsync();
            return resul > 0 ? true : false; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            var resul = await _dbContext.SaveChangesAsync();
            return resul > 0 ? true : false;
        }
    }
}

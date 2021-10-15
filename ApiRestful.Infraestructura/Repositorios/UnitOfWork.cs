using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
using ApiRestful.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Infraestructura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiRestfulContext _context;
        private readonly IRepository<Post> _postRespository;
        private readonly IRepository<User> _userRespository;
        private readonly IRepository<Comment> _commentRespository;


        public IRepository<Post> PostRepository => _postRespository ?? new BaseRepository<Post>(_context);

        public IRepository<User> UserRepository => _userRespository ?? new BaseRepository<User>(_context);

        public IRepository<Comment> CommentRepository => _commentRespository ?? new BaseRepository<Comment>(_context);

        public UnitOfWork(ApiRestfulContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}

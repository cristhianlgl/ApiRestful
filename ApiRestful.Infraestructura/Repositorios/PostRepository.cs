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
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ApiRestfulContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Post>> GetPostByUserId(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}

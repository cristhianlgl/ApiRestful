using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Infraestructura.Repositorios
{
    public class PostMysqlRepository : IPostRepository
    {
        public Task<Post> GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post()
            {
                PostId = x,
                UserId = x * 3,
                Description = $"Description para {x} de Mysql",
                Image = $"http://ok.com/imagen/{x}",
                Date = DateTime.Now
            });
            await Task.Delay(10);
            return posts;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;

namespace ApiRestful.Infraestructura.Repositorios
{
    public class PostRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            IEnumerable<Post> posts = null;
            await Task.Run(() =>
            {
               posts = Enumerable.Range(1, 10).Select(x => new Post()
               {
                   PostId = x,
                   UserId = x * 3,
                   Descripcion = $"Descripcion para {x} de SQLServer",
                   Imagen = $"http://ok.com/imagen/{x}",
                   Fecha = DateTime.Now
               });
            });
            return posts;
        }
    }
}

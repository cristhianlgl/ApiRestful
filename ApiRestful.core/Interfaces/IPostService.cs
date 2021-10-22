using ApiRestful.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostAsync(int id);
        Task InsertPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}

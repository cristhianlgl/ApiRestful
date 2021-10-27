using ApiRestful.core.Entidades;
using ApiRestful.core.EntidadesPersonalizadas;
using ApiRestful.core.QueryFilters;
using System.Threading.Tasks;

namespace ApiRestful.core.Interfaces
{
    public interface IPostService
    {
        PageList<Post> GetPosts(PostFilter postFilter);
        Task<Post> GetPostAsync(int id);
        Task InsertPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}

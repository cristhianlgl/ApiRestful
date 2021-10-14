using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
using ApiRestful.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Infraestructura.Repositorios
{
    public class PostRepository : IPostRepository
    {
        private readonly ApiRestfulContext _dbContext;
        public PostRepository(ApiRestfulContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _dbContext.Posts.ToListAsync();            
            return posts;
        }

        public async Task InsertPostAsync(Post post)
        {
            post.PostId = 0;
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var postCurrent = await GetPostAsync(post.PostId);
            postCurrent.Description = post.Description;
            postCurrent.Date = post.Date;
            postCurrent.Image = post.Image;
            var result = await _dbContext.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            var postCurrent = await GetPostAsync(id);
             _dbContext.Posts.Remove(postCurrent);
            var result = await _dbContext.SaveChangesAsync();
            return Convert.ToBoolean(result);
        }
    }
}

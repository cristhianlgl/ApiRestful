﻿using System;
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

        public async Task<Post> GetPost(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _dbContext.Posts.ToListAsync();            
            return posts;
        }
    }
}

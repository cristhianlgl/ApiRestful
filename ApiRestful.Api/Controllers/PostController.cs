using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestful.Infraestructura.Repositorios;
using ApiRestful.core.Interfaces;
using ApiRestful.core.Entidades;

namespace ApiRestful.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetPostsAsync(); 
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var posts = await _postRepository.GetPostAsync(id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(Post post)
        {
            await _postRepository.InsertPostAsync(post);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestful.Infraestructura.Repositorios;
using ApiRestful.core.Interfaces;

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
            var posts = await _postRepository.GetPosts(); 
            return Ok(posts);
        }
    }
}

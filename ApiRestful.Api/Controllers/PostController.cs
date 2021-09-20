using ApiRestful.core.DTOs;
using ApiRestful.core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiRestful.core.Entidades;

namespace ApiRestful.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetPostsAsync();
            var postsDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);            
            return Ok(postsDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPostAsync(id);
            var postDTO = _mapper.Map<PostDTO>(post);
            return Ok(postDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            await _postRepository.InsertPostAsync(post);
            return Ok();
        }
    }
}

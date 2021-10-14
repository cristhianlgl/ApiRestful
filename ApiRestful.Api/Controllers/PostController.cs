using ApiRestful.core.DTOs;
using ApiRestful.core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiRestful.core.Entidades;
using ApiRestful.Api.Responses;

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
            var resp = new ResponseApi<IEnumerable<PostDTO>>(postsDTOs, true);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPostAsync(id);
            var postDTO = _mapper.Map<PostDTO>(post);
            var resp = new ResponseApi<PostDTO>(postDTO, true);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            await _postRepository.InsertPostAsync(post);
            var postDTOCurrent = _mapper.Map<PostDTO>(post);
            var resp = new ResponseApi<PostDTO>(postDTOCurrent, true);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            post.PostId = id;
            var result = await _postRepository.UpdatePostAsync(post);
            var resp = new ResponseApi<bool>(result, result);
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _postRepository.DeletePostAsync(id);
            var resp = new ResponseApi<bool>(result, result);
            return Ok(resp);
        }
    }
}

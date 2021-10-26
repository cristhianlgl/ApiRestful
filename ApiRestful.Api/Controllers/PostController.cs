using ApiRestful.Api.Responses;
using ApiRestful.core.DTOs;
using ApiRestful.core.Entidades;
using ApiRestful.core.QueryFilters;
using ApiRestful.core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace ApiRestful.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseApi<IEnumerable<PostDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseApi<IEnumerable<PostDTO>>))]
        public IActionResult Get([FromQuery]PostFilter postFilter)
        {
            var posts = _postService.GetPosts(postFilter);
            var postsDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);
            var resp = new ResponseApi<IEnumerable<PostDTO>>(postsDTOs, true);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPostAsync(id);
            var postDTO = _mapper.Map<PostDTO>(post);
            var resp = new ResponseApi<PostDTO>(postDTO, true);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            await _postService.InsertPostAsync(post);
            var postDTOCurrent = _mapper.Map<PostDTO>(post);
            var resp = new ResponseApi<PostDTO>(postDTOCurrent, true);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            post.Id = id;
            await _postService.UpdatePostAsync(post);
            var resp = new ResponseApi<bool>(true, true);
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePostAsync(id);
            var resp = new ResponseApi<bool>(true, true);
            return Ok(resp);
        }
    }
}

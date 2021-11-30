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
using Newtonsoft.Json;
using ApiRestful.core.EntidadesPersonalizadas;
using ApiRestful.Infraestructura.Interfaces;

namespace ApiRestful.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriPostServices _uriPostServices;
        public PostController(IPostService postService, IMapper mapper, IUriPostServices uriPostServices)
        {
            _postService = postService;
            _mapper = mapper;
            _uriPostServices = uriPostServices;
        }

        /// <summary>
        /// Retorna Todos los Post Segun los parametros enviados
        /// </summary>
        /// <param name="postFilter">Filtros aplicar sobre los post</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(Get))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseApi<IEnumerable<PostDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get([FromQuery]PostFilter postFilter)
        {
            var posts = _postService.GetPosts(postFilter);
            var postsDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);
            var metadata = new Metadata
            {
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalCount = posts.TotalCount,
                TotalPages = posts.TotalPages,
                HasPreviousPage = posts.HasPreviousPage,
                HasNextPage = posts.HasNextPage,
                NextPageUri = _uriPostServices.GetNextPageUri(postFilter, Url.RouteUrl(nameof(Get))).ToString(),
                PreviousPageUri = _uriPostServices.GetPreviuosPageUri(postFilter, Url.RouteUrl(nameof(Get))).ToString()
            };
            var resp = new ResponseApi<IEnumerable<PostDTO>>(postsDTOs, metadata , true);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
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

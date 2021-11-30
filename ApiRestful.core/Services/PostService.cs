using ApiRestful.core.Entidades;
using ApiRestful.core.EntidadesPersonalizadas;
using ApiRestful.core.Excepciones;
using ApiRestful.core.Interfaces;
using ApiRestful.core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Services
{
    public class PostService: IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PostService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _unitOfWork.PostRepository.GetByIdAsync(id);
        }

        public PageList<Post> GetPosts(PostFilter filtro)
        {
            filtro.CantidadPorPagina = filtro.CantidadPorPagina == 0 ? _paginationOptions.DefaultPageSize : filtro.CantidadPorPagina;
            filtro.NumeroPagina = filtro.NumeroPagina == 0 ? _paginationOptions.DefaultCurrentPage : filtro.NumeroPagina;

            var post = _unitOfWork.PostRepository.GetAll();
            if (filtro.IdUsuario != null)
                post = post.Where(x => x.UserId == filtro.IdUsuario);
            if (filtro.Fecha != null)
                post = post.Where(x => x.Date.ToShortDateString() == filtro.Fecha?.ToShortDateString());
            if(filtro.Descripcion != null)
                post = post.Where(x => x.Description.ToLower().Contains(filtro.Descripcion.ToLower()));
            var postPageList = PageList<Post>.Create(post, filtro.NumeroPagina, filtro.CantidadPorPagina); 
            return postPageList;
        }

        public async Task InsertPostAsync(Post post)
        {
            post.Date = DateTime.Today;
            var user = await _unitOfWork.UserRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new NegocioException("El usuario no Existe");
            var postUser = await _unitOfWork.PostRepository.GetPostByUserId(post.UserId);
            if (postUser.Count() < 10)
            { 
                if( ( DateTime.Today - postUser.OrderByDescending(x => x.Date).FirstOrDefault().Date).TotalDays < 7)
                    throw new NegocioException("Solo puede postear un post a la semana");
            }
            if (post.Description.ToLower().Contains("sexo"))
                throw new NegocioException("Este tipo de contenidos no esta permitido");
            await _unitOfWork.PostRepository.InsertAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new NegocioException("El usuario no Existe");
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeletePostAsync(int id)
        {
            await _unitOfWork.PostRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}

using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
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

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _unitOfWork.PostRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _unitOfWork.PostRepository.GetAllAsync();
        }

        public async Task InsertPostAsync(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new Exception("El usuario no Existe");
            if (post.Description.ToLower().Contains("sexo"))
                throw new Exception("Este tipo de contenidos no esta permitido");
            await _unitOfWork.PostRepository.InsertAsync(post);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new Exception("El usuario no Existe");
            return await _unitOfWork.PostRepository.UpdateAsync(post);
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            return await _unitOfWork.PostRepository.DeleteAsync(id);
        }

    }
}

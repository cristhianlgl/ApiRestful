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
        private readonly IPostRepository _postReposity;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postReposity = postRepository;
            _userRepository = userRepository;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postReposity.GetPostAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _postReposity.GetPostsAsync();
        }

        public async Task InsertPostAsync(Post post)
        {
            var user = await _userRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new Exception("El usuario no Existe");
            if (post.Description.ToLower().Contains("sexo"))
                throw new Exception("Este tipo de contenidos no esta permitido");
            await _postReposity.InsertPostAsync(post);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            return await _postReposity.UpdatePostAsync(post);
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            return await _postReposity.DeletePostAsync(id);
        }

    }
}

using ApiRestful.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> PostRepository { get;  }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
        
    }
}

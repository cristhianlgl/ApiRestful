﻿using ApiRestful.core.Entidades;
using ApiRestful.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Infraestructura.Repositorios
{
    class PostMysqlRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post()
            {
                PostId = x,
                UserId = x * 3,
                Descripcion = $"Descripcion para {x} de SQLServer",
                Imagen = $"http://ok.com/imagen/{x}",
                Fecha = DateTime.Now
            });
            await Task.Delay(10);
            return posts;
        }
    }
}

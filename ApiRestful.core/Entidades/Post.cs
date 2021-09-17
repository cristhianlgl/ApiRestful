using System;

namespace ApiRestful.core.Entidades
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha { get; set; }
    }
}

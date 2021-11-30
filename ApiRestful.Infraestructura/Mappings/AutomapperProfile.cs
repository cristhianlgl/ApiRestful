using ApiRestful.core.DTOs;
using ApiRestful.core.Entidades;
using AutoMapper;

namespace ApiRestful.Infraestructura.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
        }

    }
}

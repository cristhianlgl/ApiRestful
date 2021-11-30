using ApiRestful.core.QueryFilters;
using System;

namespace ApiRestful.Infraestructura.Interfaces
{
    public interface IUriPostServices
    {
        Uri GetNextPageUri(PostFilter filters, string actionUri);
        Uri GetPreviuosPageUri(PostFilter filters, string actionUri);
    }
}
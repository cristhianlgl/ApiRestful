using ApiRestful.core.QueryFilters;
using ApiRestful.Infraestructura.Interfaces;
using System;

namespace ApiRestful.Infraestructura.Services
{
    public class UriPostServices :  IUriPostServices
    {
        protected readonly string _baseUri;
        public UriPostServices(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetNextPageUri(PostFilter filters, string actionUri)
        {
            var UriBase = $"{_baseUri}{actionUri}";
            return new Uri(UriBase);
        }

        public Uri GetPreviuosPageUri(PostFilter filters, string actionUri)
        {
            var UriBase = $"{_baseUri}{actionUri}";
            return new Uri(UriBase);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.EntidadesPersonalizadas
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalCount;

        public int? PreviuosPagesNumber => HasPreviousPage ? CurrentPage -1 : null;
        public int? NextPagesNumber => HasNextPage ? CurrentPage + 1 : null;

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int) Math.Ceiling((TotalCount / (decimal)pageSize));
            AddRange(items);    
        }

        public static PageList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }

    }
}

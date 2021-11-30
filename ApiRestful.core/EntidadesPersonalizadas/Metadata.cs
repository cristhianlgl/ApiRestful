using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.core.EntidadesPersonalizadas
{
    public class Metadata
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string PreviousPageUri { get; set; }
        public string NextPageUri { get; set; }
    }
}

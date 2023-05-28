using Bootcamp_store_backend.Application;

namespace Bootcamp_store_backend.Infrastructure.Rest
{
    public class PagedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public PagedList<T>? Data { get; set; }
    }
}
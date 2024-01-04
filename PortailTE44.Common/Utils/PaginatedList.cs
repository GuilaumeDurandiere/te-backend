namespace PortailTE44.Common.Utils
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Results { get; set; } = default!;

        public int TotalPages { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>()
            {
                Results = source.Skip((pageIndex - 1) * pageSize).Take(pageSize),
                TotalPages = source.Count(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        }
    }
}


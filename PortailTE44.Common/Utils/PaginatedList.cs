namespace PortailTE44.Common.Utils
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Results { get; set; } = default!;

        public int Total { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}


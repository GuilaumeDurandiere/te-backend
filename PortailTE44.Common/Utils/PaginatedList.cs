namespace PortailTE44.Common.Utils
{
	public class PaginatedList<T> : List<T>
	{
		public int PageIndex { get; private set; }
		public int TotalPages { get; private set; }
		public PaginatedList(List<T> list, int count, int pageIndex, int pageSize)
		{
			this.AddRange(list);
			this.PageIndex = pageIndex;
			this.TotalPages = (int) Math.Ceiling(count / (double) pageSize);
		}

		public bool HasPreviousPage => PageIndex > 1;

		public bool HasNextPage => PageIndex < TotalPages;

		public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return new PaginatedList<T>(items, count, pageIndex, pageIndex);
		}
	}
}


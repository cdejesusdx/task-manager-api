namespace InsolTech.TaskManager.Application.Common
{
    /// <summary>
    /// Contenedor genérico para resultados paginados.
    /// </summary>
    public class PaginatedList<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items.ToList().AsReadOnly();
            TotalCount = count;
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,
                                                               int pageIndex, int pageSize,
                                                               CancellationToken ct = default)
        {
            var count = await Task.Run(() => source.Count(), ct);
            var items = await Task.Run(() => source.Skip((pageIndex - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToList(), ct);
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
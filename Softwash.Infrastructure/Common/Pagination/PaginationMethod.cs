namespace Softwash.Infrastructure.Common.Pagination;

public class PaginatedListDTO<T> : List<T>
{

    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedListDTO(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public bool HasPreviousPage
    {
        get
        {
            return PageIndex > 1;
        }
    }

    public bool HasNextPage
    {
        get
        {
            return PageIndex < TotalPages;
        }
    }


}
public static class QueryExtensions
{
    public static async Task<PaginatedListDTO<T>> ToPaggedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedListDTO<T>(items, count, pageNumber, pageSize);
    }
    public static PaginatedListDTO<T> ToPaggedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize) where T : class
    {
        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedListDTO<T>(items, count, pageNumber, pageSize);
    }


}

namespace Softwash.Infrastructure.Common.Pagination;

public class PaginationDTO
{
    [DefaultValue(1)]
    public int PageNo { get; set; } = 1;
    [DefaultValue(10)]
    public int Size { get; set; } = 10;
    public string? Search { get; set; }
    [DefaultValue(true)]
    public bool IsPagination { get; set; } = true;
    public string? SortBy { get; set; }
    public string? SortDirection { get; set; }
}

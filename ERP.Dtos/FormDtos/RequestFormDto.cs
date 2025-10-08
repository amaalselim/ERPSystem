namespace ERP.Dtos.FormDtos
{
    public record RequestFormDto(
        int PageNumber,
        int PageSize,
        string? SortColumn,
        string? Dir,
        string? Search
    );
}

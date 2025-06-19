using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;


namespace Study.Lab3.Web.Features.University.ScientificWork.DtoModels;

public sealed record PagedResult<T>
{
    public IEnumerable<T> Items { get; init; }
    public int TotalCount { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
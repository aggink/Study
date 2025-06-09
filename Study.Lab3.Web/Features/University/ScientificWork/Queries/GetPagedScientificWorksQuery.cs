using MediatR;
using Study.Lab3.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;

namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetPagedScientificWorksQuery : IRequest<PagedResult<ScientificWorkDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string SortBy { get; init; } = "PublicationDate";
        public bool SortDescending { get; init; } = true;
    }
public class GetPagedScientificWorksQueryHandler
        : IRequestHandler<GetPagedScientificWorksQuery, PagedResult<ScientificWorkDto>>
{
    private readonly DataContext _context;

    public GetPagedScientificWorksQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<ScientificWorkDto>> Handle(
        GetPagedScientificWorksQuery request,
        CancellationToken cancellationToken)
    {
        // Базовый запрос с фильтрацией (если нужно)
        var query = _context.ScientificWorks.AsQueryable();

        // Сортировка
        query = request.SortBy switch
        {
            "Title" => request.SortDescending
                ? query.OrderByDescending(sw => sw.Title)
                : query.OrderBy(sw => sw.Title),
            "PublicationDate" => request.SortDescending
                ? query.OrderByDescending(sw => sw.PublicationDate)
                : query.OrderBy(sw => sw.PublicationDate),
            _ => query // Сортировка по умолчанию
        };

        // Пагинация
        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(sw => new ScientificWorkDto
            {
                IsnScientificWork = sw.IsnScientificWork,
                IsnStudent = sw.IsnStudent,
                IsnSubject = sw.IsnSubject,
                Title = sw.Title,
                Description = sw.Description,
                PageCount = sw.PageCount,
                PublicationDate = sw.PublicationDate,
                IsPublished = sw.IsPublished
            })
            .ToListAsync(cancellationToken);

        return new PagedResult<ScientificWorkDto>
        {
            Items = items,
            TotalCount = totalItems,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
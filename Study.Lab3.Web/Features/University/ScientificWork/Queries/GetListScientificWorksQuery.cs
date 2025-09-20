using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;


namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;

public record GetListScientificWorksQuery : IRequest<ScientificWorkDto[]>
{
    public Guid? IsnStudent { get; init; }
    public Guid? IsnSubject { get; init; }
    public bool? IsPublished { get; init; }
}

public class GetListScientificWorksQueryHandler
    : IRequestHandler<GetListScientificWorksQuery, ScientificWorkDto[]>
{
    private readonly DataContext _context;

    public GetListScientificWorksQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<ScientificWorkDto[]> Handle(
        GetListScientificWorksQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.ScientificWorks.AsQueryable();

        if (request.IsnStudent.HasValue)
            query = query.Where(sw => sw.IsnStudent == request.IsnStudent);

        if (request.IsnSubject.HasValue)
            query = query.Where(sw => sw.IsnSubject == request.IsnSubject);


        var result = await query
            .Select(sw => new ScientificWorkDto
            {
                IsnScientificWork = sw.IsnScientificWork,
                IsnStudent = sw.IsnStudent,
                IsnSubject = sw.IsnSubject,
                Title = sw.Title,
                Description = sw.Description,
                PageCount = sw.PageCount,
            })
            .ToArrayAsync(cancellationToken);

        return result;
    }
}
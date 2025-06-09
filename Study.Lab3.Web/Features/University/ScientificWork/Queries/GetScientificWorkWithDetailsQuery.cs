using MediatR;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;


namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetScientificWorkWithDetailsQuery : IRequest<ScientificWorkWithDetailsDto>
    {
        public Guid IsnScientificWork { get; init; }
    }
public class GetScientificWorkWithDetailsQueryHandler
        : IRequestHandler<GetScientificWorkWithDetailsQuery, ScientificWorkWithDetailsDto>
{
    private readonly DataContext _context;

    public GetScientificWorkWithDetailsQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<ScientificWorkWithDetailsDto> Handle(
        GetScientificWorkWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var scientificWork = await _context.ScientificWorks
            .AsNoTracking()
            .Include(sw => sw.Student) // Подгружаем данные об авторе
            .Include(sw => sw.Subject) // Подгружаем данные о предмете
            .FirstOrDefaultAsync(sw => sw.IsnScientificWork == request.IsnScientificWork,
                cancellationToken);

        if (scientificWork == null)
        {
            throw new Exception($"Scientific work with ID {request.IsnScientificWork} not found.");
        }

        return new ScientificWorkWithDetailsDto
        {
            IsnScientificWork = scientificWork.IsnScientificWork,
            Title = scientificWork.Title,
            Description = scientificWork.Description,
            PageCount = scientificWork.PageCount,
            PublicationDate = scientificWork.PublicationDate,
            IsPublished = scientificWork.IsPublished,


        };
    }
}
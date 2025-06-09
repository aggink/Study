using MediatR;
using Study.Lab3.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;

namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetScientificWorkByIsnQuery : IRequest<ScientificWorkDto>
    {
        public Guid IsnScientificWork { get; init; }
    }
public class GetScientificWorkByIsnQueryHandler
        : IRequestHandler<GetScientificWorkByIsnQuery, ScientificWorkDto>
{
    private readonly DataContext _context;

    public GetScientificWorkByIsnQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<ScientificWorkDto> Handle(
        GetScientificWorkByIsnQuery request,
        CancellationToken cancellationToken)
    {
        var scientificWork = await _context.ScientificWorks
            .AsNoTracking() // Оптимизация: отключаем отслеживание изменений
            .FirstOrDefaultAsync(sw => sw.IsnScientificWork == request.IsnScientificWork,
                cancellationToken);

        if (scientificWork == null)
        {
            throw new Exception($"Scientific work with ID {request.IsnScientificWork} not found.");
            // Или вернуть null, если предпочтительнее: return null;
        }

        return new ScientificWorkDto
        {
            IsnScientificWork = scientificWork.IsnScientificWork,
            IsnStudent = scientificWork.IsnStudent,
            IsnSubject = scientificWork.IsnSubject,
            Title = scientificWork.Title,
            Description = scientificWork.Description,
            PageCount = scientificWork.PageCount,
            PublicationDate = scientificWork.PublicationDate,
            IsPublished = scientificWork.IsPublished
        };
    }
}
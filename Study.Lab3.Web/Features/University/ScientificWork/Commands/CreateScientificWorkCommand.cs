using MediatR;
using Study.Lab3.Storage.Database;


namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;

public record CreateScientificWorkCommand : IRequest<Guid>
{
    public CreateScientificWorkDto ScientificWorkDto { get; init; }
}
public class CreateScientificWorkCommandHandler : IRequestHandler<CreateScientificWorkCommand, Guid>
{
    private readonly DataContext _context;

    public CreateScientificWorkCommandHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var dto = request.ScientificWorkDto;
        var scientificWork = new Storage.Models.University.ScientificWork
        {
            IsnScientificWork = Guid.NewGuid(),
            IsnStudent = request.ScientificWorkDto.IsnStudent,  // Доступ через DTO
            IsnSubject = request.ScientificWorkDto.IsnSubject,
            Title = request.ScientificWorkDto.Title,
            Description = request.ScientificWorkDto.Description,
            PageCount = request.ScientificWorkDto.PageCount,
            PublicationDate = request.ScientificWorkDto.PublicationDate,
            IsPublished = request.ScientificWorkDto.IsPublished
        };

        _context.ScientificWorks.Add(scientificWork);
        await _context.SaveChangesAsync(cancellationToken);

        return scientificWork.IsnScientificWork;
    }
}

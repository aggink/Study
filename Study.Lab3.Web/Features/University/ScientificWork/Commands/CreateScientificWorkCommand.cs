using MediatR;
using Study.Lab3.Storage.Database;


namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;

public record CreateScientificWorkCommand : IRequest<Guid>
{
    public Guid IsnStudent { get; init; }
    public Guid IsnSubject { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int PageCount { get; init; }
    public DateTime PublicationDate { get; init; }
    public bool IsPublished { get; init; }
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
        var scientificWork = new Storage.Models.University.ScientificWork
        {
            IsnScientificWork = Guid.NewGuid(), // Primary key
            IsnStudent = request.IsnStudent,
            IsnSubject = request.IsnSubject,
            Title = request.Title,
            Description = request.Description,
            PageCount = request.PageCount,
            PublicationDate = request.PublicationDate,
            IsPublished = request.IsPublished
        };

        _context.ScientificWorks.Add(scientificWork);
        await _context.SaveChangesAsync(cancellationToken);

        return scientificWork.IsnScientificWork;
    }
}

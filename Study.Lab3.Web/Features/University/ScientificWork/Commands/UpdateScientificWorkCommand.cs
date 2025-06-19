using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;


namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;

public record UpdateScientificWorkCommand : IRequest<Guid>
{
    public Guid IsnScientificWork { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int PageCount { get; init; }
    public bool IsPublished { get; init; }
}

public class UpdateScientificWorkCommandHandler : IRequestHandler<UpdateScientificWorkCommand, Guid>
{
    private readonly DataContext _context;

    public UpdateScientificWorkCommandHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var scientificWork = await _context.ScientificWorks
            .FirstOrDefaultAsync(sw => sw.IsnScientificWork == request.IsnScientificWork, cancellationToken);

        if (scientificWork == null)
        {
            throw new Exception($"Scientific work with ID {request.IsnScientificWork} not found.");
        }

        scientificWork.Title = request.Title;
        scientificWork.Description = request.Description;
        scientificWork.PageCount = request.PageCount;

        _context.ScientificWorks.Update(scientificWork);
        await _context.SaveChangesAsync(cancellationToken);

        return scientificWork.IsnScientificWork;
    }
}
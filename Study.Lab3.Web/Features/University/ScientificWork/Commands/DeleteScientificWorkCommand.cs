using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;
//public record DeleteScientificWorkCommand : IRequest<Unit>
//    {
//        public Guid IsnScientificWork { get; init; }
//}

 public record DeleteScientificWorkCommand(Guid IsnScientificWork) : IRequest<bool>;
    // Ключевая часть: ": IRequest<bool>"
public class DeleteScientificWorkCommandHandler : IRequestHandler<DeleteScientificWorkCommand, bool >
{
    private readonly DataContext _context;

    public DeleteScientificWorkCommandHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteScientificWorkCommand request, CancellationToken cancellationToken)
    {
        var scientificWork = await _context.ScientificWorks
            .FirstOrDefaultAsync(sw => sw.IsnScientificWork == request.IsnScientificWork, cancellationToken);

        if (scientificWork == null)
        {
            return false; // или throw new Exception("Not found");
        }

        _context.ScientificWorks.Remove(scientificWork);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
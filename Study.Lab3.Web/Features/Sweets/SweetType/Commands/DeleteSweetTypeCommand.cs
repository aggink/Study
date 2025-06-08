using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Commands;
=======
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetType.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Удаление элемента из SweetType
/// </summary>
public sealed class DeleteSweetTypeCommand : IRequest
{
    /// <summary>
    /// Идентификатор сладости
    /// </summary>
    [Required]
    [FromQuery]
    public SweetTypeDto SweetType { get; init; }
}

public sealed class DeleteSweetTypeCommandHandler : IRequestHandler<DeleteSweetTypeCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSweetTypeCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSweetTypeCommand request, CancellationToken cancellationToken)
    {
        var sweettype = await _dataContext.SweetTypes.FirstOrDefaultAsync(c => c.IsnSweetType == request.SweetType.IsnSweetType, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Sweet type с идентификатором \"{request.SweetType.IsnSweetType}\" не существует");

        // Удаление записи
        _dataContext.SweetTypes.Remove(sweettype);
<<<<<<< HEAD
        
=======

>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
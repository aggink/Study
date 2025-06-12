using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.Commands;

/// <summary>
/// Редактирование группы
/// </summary>
public sealed class UpdateLabCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [Required]
    [FromBody]
    public UpdateLabDto Lab { get; init; }
}

public sealed class UpdateLabCommandHandler : IRequestHandler<UpdateLabCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public UpdateLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task<Guid> Handle(UpdateLabCommand request, CancellationToken cancellationToken)
    {
        var lab = await _dataContext.Labs.FirstOrDefaultAsync(x => x.IsnLab == request.Lab.IsnLab, cancellationToken)
            ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.Lab.IsnLab}\" не существует");

        lab.Name = request.Lab.Name;

        await _labService.CreateOrUpdateLabValidateAndThrowAsync(
            _dataContext, lab, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return lab.IsnLab;
    }
}

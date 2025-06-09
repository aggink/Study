using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;
namespace Study.Lab3.Web.Features.University.Labs.Commands;

/// <summary>
/// Создание группы
/// </summary>
public sealed class CreateLabCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные группы
    /// </summary>
    [FromBody]
    [Required]
    public CreateLabDto Lab { get; init; }
}

public sealed class CreateLabCommandHandler : IRequestHandler<CreateLabCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ILabService _labService;

    public CreateLabCommandHandler(
        DataContext dataContext,
        ILabService labService)
    {
        _dataContext = dataContext;
        _labService = labService;
    }

    public async Task<Guid> Handle(CreateLabCommand request, CancellationToken cancellationToken)
    {
        var lab = new Lab3.Storage.Models.University.Labs
        {
            IsnLab = Guid.NewGuid(),
            Name = request.Lab.Name
        };

        await _labService.CreateOrUpdateLabValidateAndThrowAsync(
            _dataContext, lab, cancellationToken);

        await _dataContext.Labs.AddAsync(lab, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return lab.IsnLab;
    }
}

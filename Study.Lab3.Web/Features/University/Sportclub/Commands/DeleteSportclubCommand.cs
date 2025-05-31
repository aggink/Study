using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Commands;

/// <summary>
/// �������� ����������� �����
/// </summary>
public sealed class DeleteSportclubCommand : IRequest
{
    /// <summary>
    /// ������������� ����������� �����
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSportclub { get; init; }
}

public sealed class DeleteSportclubCommandHandler : IRequestHandler<DeleteSportclubCommand>
{
    private readonly DataContext _dataContext;
    private readonly ISportclubService _sportclubService;

    public DeleteSportclubCommandHandler(
        DataContext dataContext,
        ISportclubService sportclubService)
    {
        _dataContext = dataContext;
        _sportclubService = sportclubService;
    }

    public async Task Handle(DeleteSportclubCommand request, CancellationToken cancellationToken)
    {
        var sportclub = await _dataContext.Sportclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnSportclub == request.IsnSportclub, cancellationToken)
                ?? throw new BusinessLogicException($"������������ � ��������������� \"{request.IsnSportclub}\" �� ����������");

        await _sportclubService.CanDeleteAndThrowAsync(
            _dataContext, sportclub, cancellationToken);

        _dataContext.Sportclub.Remove(sportclub);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
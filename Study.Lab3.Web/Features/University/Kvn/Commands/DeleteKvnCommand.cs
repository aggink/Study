using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheKvn.Commands;

/// <summary>
/// �������� ���
/// </summary>
public sealed class DeleteKvnCommand : IRequest
{
    /// <summary>
    /// ������������� ���
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnKvn { get; init; }
}

public sealed class DeleteKvnCommandHandler : IRequestHandler<DeleteKvnCommand>
{
    private readonly DataContext _dataContext;
    private readonly IKvnService _kvnService;

    public DeleteKvnCommandHandler(
        DataContext dataContext,
        IKvnService kvnService)
    {
        _dataContext = dataContext;
        _kvnService = kvnService;
    }

    public async Task Handle(DeleteKvnCommand request, CancellationToken cancellationToken)
    {
        var kvn = await _dataContext.TheKvn
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnKvn == request.IsnKvn, cancellationToken)
                ?? throw new BusinessLogicException($"����������� � ��������������� \"{request.IsnKvn}\" �� ����������");

        await _kvnService.CanDeleteAndThrowAsync(
            _dataContext, kvn, cancellationToken);

        _dataContext.TheKvn.Remove(kvn);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
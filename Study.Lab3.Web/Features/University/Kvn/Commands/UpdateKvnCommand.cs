using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Kvn.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Kvn.Commands;

/// <summary>
/// Редактирование квн
/// </summary>
public sealed class UpdateKvnCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные квн
    /// </summary>
    [Required]
    [FromBody]
    public UpdateKvnDto Kvn { get; init; }
}

public sealed class UpdateKvnCommandHandler : IRequestHandler<UpdateKvnCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IKvnService _kvnService;

    public UpdateKvnCommandHandler(
        DataContext dataContext,
        IKvnService kvnService)
    {
        _dataContext = dataContext;
        _kvnService = kvnService;
    }

    public async Task<Guid> Handle(UpdateKvnCommand request, CancellationToken cancellationToken)
    {
        var profcom = await _dataContext.TheKvn
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnKvn == request.Kvn.IsnKvn, cancellationToken)
                ?? throw new BusinessLogicException($"Выступления с идентификатором \"{request.Kvn.IsnKvn}\" не существует");

        profcom.ParticipantsCount = request.Kvn.ParticipantsCount;
        profcom.KvnDate = request.Kvn.KvnDate;

        await _kvnService.CreateOrUpdateKvnValidateAndThrowAsync(
            _dataContext, profcom, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return profcom.IsnKvn;
    }
}
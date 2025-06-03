using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheKvn.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheKvn.Commands;

/// <summary>
/// Создание квн
/// </summary>
public sealed class CreateKvnCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные квн
    /// </summary>
    [Required]
    [FromBody]
    public CreateKvnDto Kvn { get; init; }
}

public sealed class CreateKvnCommandHandler : IRequestHandler<CreateKvnCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IKvnService _kvnService;

    public CreateKvnCommandHandler(
        DataContext dataContext,
        IKvnService kvnService)
    {
        _dataContext = dataContext;
        _kvnService = kvnService;
    }

    public async Task<Guid> Handle(CreateKvnCommand request, CancellationToken cancellationToken)
    {
        var kvn = new Kvn
        {
            IsnKvn = Guid.NewGuid(),
            IsnStudent = request.Kvn.IsnStudent,
            IsnSubject = request.Kvn.IsnSubject,
            ParticipantsCount = request.Kvn.ParticipantsCount,
            KvnDate = request.Kvn.KvnDate
        };

        await _kvnService.CreateOrUpdateKvnValidateAndThrowAsync(
            _dataContext, kvn, cancellationToken);

        await _dataContext.TheKvn.AddAsync(kvn, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return kvn.IsnKvn;
    }
}
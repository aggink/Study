using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Commands;

/// <summary>
/// Удаление спортивного клуба
/// </summary>
public sealed class DeletePingpongclubCommand : IRequest
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPingpongclub { get; init; }
}

public sealed class DeletePingpongclubCommandHandler : IRequestHandler<DeletePingpongclubCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPingpongclubService _PingpongclubService;

    public DeletePingpongclubCommandHandler(
        DataContext dataContext,
        IPingpongclubService PingpongclubService)
    {
        _dataContext = dataContext;
        _PingpongclubService = PingpongclubService;
    }

    public async Task Handle(DeletePingpongclubCommand request, CancellationToken cancellationToken)
    {
        var Pingpongclub = await _dataContext.Pingpongclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnPingpongclub == request.IsnPingpongclub, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.IsnPingpongclub}\" не существует");

        await _PingpongclubService.CanDeleteAndThrowAsync(
            _dataContext, Pingpongclub, cancellationToken);

        _dataContext.Pingpongclub.Remove(Pingpongclub);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
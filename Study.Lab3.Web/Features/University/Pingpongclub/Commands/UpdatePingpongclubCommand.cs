using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Commands;

/// <summary>
/// Редактирование спортивного клуба
/// </summary>
public sealed class UpdatePingpongclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные спортивного клуба
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePingpongclubDto Pingpongclub { get; init; }
}

public sealed class UpdatePingpongclubCommandHandler : IRequestHandler<UpdatePingpongclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPingpongclubService _PingpongclubService;

    public UpdatePingpongclubCommandHandler(
        DataContext dataContext,
        IPingpongclubService PingpongclubService)
    {
        _dataContext = dataContext;
        _PingpongclubService = PingpongclubService;
    }

    public async Task<Guid> Handle(UpdatePingpongclubCommand request, CancellationToken cancellationToken)
    {
        var Pingpongclub = await _dataContext.Pingpongclub
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnPingpongclub == request.Pingpongclub.IsnPingpongclub, cancellationToken)
                ?? throw new BusinessLogicException($"Соревнований с идентификатором \"{request.Pingpongclub.IsnPingpongclub}\" не существует");

        Pingpongclub.ParticipantsCount = request.Pingpongclub.ParticipantsCount;
        Pingpongclub.PingpongclubDate = request.Pingpongclub.PingpongclubDate;

        await _PingpongclubService.CreateOrUpdatePingpongclubValidateAndThrowAsync(
            _dataContext, Pingpongclub, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return Pingpongclub.IsnPingpongclub;
    }
}
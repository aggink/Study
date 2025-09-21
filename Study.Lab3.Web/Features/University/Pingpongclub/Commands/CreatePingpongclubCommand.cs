using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Commands;

/// <summary>
/// Создание профкома
/// </summary>
public sealed class CreatePingpongclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные профкома
    /// </summary>
    [Required]
    [FromBody]
    public CreatePingpongclubDto Pingpongclub { get; init; }
}

public sealed class CreatePingpongclubCommandHandler : IRequestHandler<CreatePingpongclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPingpongclubService _PingpongclubService;

    public CreatePingpongclubCommandHandler(
        DataContext dataContext,
        IPingpongclubService PingpongclubService)
    {
        _dataContext = dataContext;
        _PingpongclubService = PingpongclubService;
    }

    public async Task<Guid> Handle(CreatePingpongclubCommand request, CancellationToken cancellationToken)
    {
        var Pingpongclub = new Storage.Models.University.Pingpongclub
        {
            IsnPingpongclub = Guid.NewGuid(),
            IsnStudent = request.Pingpongclub.IsnStudent,
            IsnSubject = request.Pingpongclub.IsnSubject,
            ParticipantsCount = request.Pingpongclub.ParticipantsCount,
            PingpongclubDate = request.Pingpongclub.PingpongclubDate
        };

        await _PingpongclubService.CreateOrUpdatePingpongclubValidateAndThrowAsync(
            _dataContext, Pingpongclub, cancellationToken);

        await _dataContext.Pingpongclub.AddAsync(Pingpongclub, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return Pingpongclub.IsnPingpongclub;
    }
}
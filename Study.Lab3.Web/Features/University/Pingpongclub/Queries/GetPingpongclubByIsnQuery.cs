using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Queries;

/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetPingpongclubByIsnQuery : IRequest<PingpongclubDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPingpongclub { get; init; }
}

public sealed class GetPingpongclubByIsnQueryHandler : IRequestHandler<GetPingpongclubByIsnQuery, PingpongclubDto>
{
    private readonly DataContext _dataContext;

    public GetPingpongclubByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PingpongclubDto> Handle(GetPingpongclubByIsnQuery request, CancellationToken cancellationToken)
    {
        var Pingpongclub = await _dataContext.Pingpongclub
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnPingpongclub == request.IsnPingpongclub, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnPingpongclub}\" не существует");

        return new PingpongclubDto
        {
            IsnPingpongclub = Pingpongclub.IsnPingpongclub,
            IsnStudent = Pingpongclub.IsnStudent,
            IsnSubject = Pingpongclub.IsnSubject,
            ParticipantsCount = Pingpongclub.ParticipantsCount,
            PingpongclubDate = Pingpongclub.PingpongclubDate
        };
    }
}
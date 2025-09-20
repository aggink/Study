using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Pingpongclub.DtoModels;

namespace Study.Lab3.Web.Features.University.Pingpongclub.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetPingpongclubWithDetailsQuery : IRequest<PingpongclubWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества участников
    /// </summary>
    [Required]
    public Guid IsnPingpongclub { get; init; }
}

public sealed class GetPingpongclubWithDetailsQueryHandler : IRequestHandler<GetPingpongclubWithDetailsQuery, PingpongclubWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetPingpongclubWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PingpongclubWithDetailsDto> Handle(GetPingpongclubWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Pingpongclub
            .AsNoTracking()
            .Where(x => x.IsnPingpongclub == request.IsnPingpongclub)
            .Select(Pingpongclub => new PingpongclubWithDetailsDto
            {
                IsnPingpongclub = Pingpongclub.IsnPingpongclub,
                IsnStudent = Pingpongclub.IsnStudent,
                StudentFullName = $"{Pingpongclub.Student.SurName} {Pingpongclub.Student.Name} {Pingpongclub.Student.PatronymicName}",
                IsnSubject = Pingpongclub.IsnSubject,
                SubjectName = Pingpongclub.Subject.Name,
                ParticipantsCount = Pingpongclub.ParticipantsCount,
                PingpongclubDate = Pingpongclub.PingpongclubDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
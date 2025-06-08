using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.Queries;

/// <summary>
/// Получить количество участников с деталями
/// </summary>
public sealed class GetProfcomWithDetailsQuery : IRequest<ProfcomWithDetailsDto>
{
	/// <summary>
	/// Идентификатор количества участников
	/// </summary>
	[Required]
	public Guid IsnProfcom { get; init; }
}

public sealed class GetProfcomWithDetailsQueryHandler : IRequestHandler<GetProfcomWithDetailsQuery, ProfcomWithDetailsDto>
{
	private readonly DataContext _dataContext;

	public GetProfcomWithDetailsQueryHandler(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task<ProfcomWithDetailsDto> Handle(GetProfcomWithDetailsQuery request, CancellationToken cancellationToken)
	{
		return await _dataContext.TheProfcom
			.AsNoTracking()
			.Where(x => x.IsnProfcom == request.IsnProfcom)
			.Select(profcom => new ProfcomWithDetailsDto
			{
				IsnProfcom = profcom.IsnProfcom,
				IsnStudent = profcom.IsnStudent,
				StudentFullName = $"{profcom.Student.SurName} {profcom.Student.Name} {profcom.Student.PatronymicName}",
				IsnSubject = profcom.IsnSubject,
				SubjectName = profcom.Subject.Name,
				ParticipantsCount = profcom.ParticipantsCount,
				ProfcomDate = profcom.ProfcomDate,
				Audience = profcom.Audience,
			})
			.FirstOrDefaultAsync(cancellationToken);
	}
}
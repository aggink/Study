using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.Queries;
//хихи хаха
/// <summary>
/// Получить количество участников по идентификатору
/// </summary>
public sealed class GetProfcomByIsnQuery : IRequest<ProfcomDto>
{
	/// <summary>
	/// Идентификатор количества участников
	/// </summary>
	[Required]
	[FromQuery]
	public Guid IsnProfcom { get; init; }
}

public sealed class GetProfcomByIsnQueryHandler : IRequestHandler<GetProfcomByIsnQuery, ProfcomDto>
{
	private readonly DataContext _dataContext;

	public GetProfcomByIsnQueryHandler(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task<ProfcomDto> Handle(GetProfcomByIsnQuery request, CancellationToken cancellationToken)
	{
		var profcom = await _dataContext.TheProfcom
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.IsnProfcom == request.IsnProfcom, cancellationToken)
				?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnProfcom}\" не существует");

		return new ProfcomDto
		{
			IsnProfcom = profcom.IsnProfcom,
			IsnStudent = profcom.IsnStudent,
			IsnSubject = profcom.IsnSubject,
			ParticipantsCount = profcom.ParticipantsCount,
			ProfcomDate = profcom.ProfcomDate,
		};
	}
}
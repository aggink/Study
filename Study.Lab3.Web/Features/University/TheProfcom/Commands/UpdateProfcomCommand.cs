using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.Commands;

/// <summary>
/// Редактирование профкома
/// </summary>
public sealed class UpdateProfcomCommand : IRequest<Guid>
{
	/// <summary>
	/// Данные профкома
	/// </summary>
	[Required]
	[FromBody]
	public UpdateProfcomDto Profcom { get; init; }
}

public sealed class UpdateProfcomCommandHandler : IRequestHandler<UpdateProfcomCommand, Guid>
{
	private readonly DataContext _dataContext;
	private readonly IProfcomService _profcomService;

	public UpdateProfcomCommandHandler(
		DataContext dataContext,
		IProfcomService profcomService)
	{
		_dataContext = dataContext;
		_profcomService = profcomService;
	}

	public async Task<Guid> Handle(UpdateProfcomCommand request, CancellationToken cancellationToken)
	{
		var profcom = await _dataContext.TheProfcom
			.Include(x => x.Subject)
			.FirstOrDefaultAsync(x => x.IsnProfcom == request.Profcom.IsnProfcom, cancellationToken)
				?? throw new BusinessLogicException($"Научной встречи с идентификатором \"{request.Profcom.IsnProfcom}\" не существует");

		profcom.ParticipantsCount = request.Profcom.ParticipantsCount;
		profcom.ProfcomDate = request.Profcom.ProfcomDate;

		await _profcomService.CreateOrUpdateProfcomValidateAndThrowAsync(
			_dataContext, profcom, cancellationToken);

		await _dataContext.SaveChangesAsync(cancellationToken);
		return profcom.IsnProfcom;
	}
}
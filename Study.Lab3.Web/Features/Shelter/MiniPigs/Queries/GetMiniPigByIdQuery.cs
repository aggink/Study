using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigs.Queries;

/// <summary>
/// Получение мини пига по идентификатору
/// </summary>
public sealed class GetMiniPigByIdQuery : IRequest<MiniPigDto>
{
	/// <summary>
	/// Идентификатор минии пига
	/// </summary>
	[Required]
	[FromQuery]
	public Guid IsnMiniPig { get; init; }
}

public sealed class GetMiniPigByIdQueryHandler : IRequestHandler<GetMiniPigByIdQuery, MiniPigDto>
{
	private readonly DataContext _dataContext;

	public GetMiniPigByIdQueryHandler(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task<MiniPigDto> Handle(GetMiniPigByIdQuery request, CancellationToken cancellationToken)
	{
		var minipig = await _dataContext.MiniPigs
					  .AsNoTracking()
					  .FirstOrDefaultAsync(c => c.IsnMiniPig == request.IsnMiniPig, cancellationToken)
				  ?? throw new BusinessLogicException(
					  $"Мини пиг с идентификатором \"{request.IsnMiniPig}\" не существует");

		return new MiniPigDto
		{
			IsnMiniPig = minipig.IsnMiniPig,
			Nickname = minipig.Nickname,
			BirthDate = minipig.BirthDate,
			Description = minipig.Description,
			Breed = minipig.Breed,
			IsVaccinated = minipig.IsVaccinated,
			IsSterilized = minipig.IsSterilized,
			Color = minipig.Color,
			MedicalHistory = minipig.MedicalHistory,
			PhotoUrl = minipig.PhotoUrl,
			ArrivalDate = minipig.ArrivalDate,
			IsAvailableForAdoption = minipig.IsAvailableForAdoption,
			Age = minipig.Age,
			Weight = minipig.Weight
		};
	}
}
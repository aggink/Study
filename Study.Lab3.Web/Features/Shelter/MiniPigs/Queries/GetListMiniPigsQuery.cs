using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.MiniPigs.Queries;

/// <summary>
/// Получение списка мини пигов
/// </summary>
public sealed class GetListMiniPigsQuery : IRequest<MiniPigDto[]>
{
}

public sealed class GetListMiniPigsQueryHandler : IRequestHandler<GetListMiniPigsQuery, MiniPigDto[]>
{
	private readonly DataContext _dataContext;

	public GetListMiniPigsQueryHandler(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task<MiniPigDto[]> Handle(GetListMiniPigsQuery request, CancellationToken cancellationToken)
	{
		return await _dataContext.MiniPigs
			.AsNoTracking()
			.OrderBy(c => c.Nickname)
			.Select(c => new MiniPigDto
			{
				IsnMiniPig = c.IsnMiniPig,
				Nickname = c.Nickname,
				BirthDate = c.BirthDate,
				Description = c.Description,
				Breed = c.Breed,
				IsVaccinated = c.IsVaccinated,
				IsSterilized = c.IsSterilized,
				Color = c.Color,
				MedicalHistory = c.MedicalHistory,
				PhotoUrl = c.PhotoUrl,
				ArrivalDate = c.ArrivalDate,
				IsAvailableForAdoption = c.IsAvailableForAdoption,
				Age = c.Age,
				Weight = c.Weight
			})
			.ToArrayAsync(cancellationToken);
	}
}
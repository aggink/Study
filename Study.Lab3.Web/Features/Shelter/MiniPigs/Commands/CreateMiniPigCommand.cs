using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;
using System.ComponentModel.DataAnnotations;


namespace Study.Lab3.Web.Features.Shelter.MiniPigs.Commands;

/// <summary>
/// Создание мини пига
/// </summary>
public class CreateMiniPigCommand : IRequest<Guid>
{
	/// <summary>
	/// Данные мини пига
	/// </summary>
	[Required]
	[FromBody]
	public CreateMiniPigDto Customer { get; init; }
}

public sealed class CreateMiniPigCommandHandler : IRequestHandler<CreateMiniPigCommand, Guid>
{
	private readonly DataContext _dataContext;

	public CreateMiniPigCommandHandler(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task<Guid> Handle(CreateMiniPigCommand request, CancellationToken cancellationToken)
	{
		var minipig = new MiniPig
		{
			IsnMiniPig = Guid.NewGuid(),
			Nickname = request.Customer.Nickname,
			BirthDate = request.Customer.BirthDate,
			Breed = request.Customer.Breed,
			IsVaccinated = request.Customer.IsVaccinated,
			IsSterilized = request.Customer.IsSterilized,
			Color = request.Customer.Color,
			MedicalHistory = request.Customer.MedicalHistory,
			PhotoUrl = request.Customer.PhotoUrl,
			ArrivalDate = request.Customer.ArrivalDate,
			Age = request.Customer.Age,
			Weight = request.Customer.Weight,
			IsAvailableForAdoption = true
		};

		await _dataContext.MiniPigs.AddAsync(minipig, cancellationToken);
		await _dataContext.SaveChangesAsync(cancellationToken);

		return minipig.IsnMiniPig;
	}
}
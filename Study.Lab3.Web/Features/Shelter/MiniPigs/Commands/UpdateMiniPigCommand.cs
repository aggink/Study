using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.MiniPigs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigs.Commands;

/// <summary>
/// Обновление клиента
/// </summary>
public sealed class UpdateMiniPigCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMiniPigDto MiniPig { get; init; }
}

public sealed class UpdateMiniPigCommandHandler : IRequestHandler<UpdateMiniPigCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateMiniPigCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateMiniPigCommand request, CancellationToken cancellationToken)
    {
        var minipig = await _dataContext.MiniPigs
            .FirstOrDefaultAsync(c => c.IsnMiniPig == request.MiniPig.IsnMiniPig, cancellationToken)
            ?? throw new BusinessLogicException($"Мини пиг с идентификатором \"{request.MiniPig.IsnMiniPig}\" не существует");

        minipig.Nickname = request.MiniPig.Nickname;
        minipig.BirthDate = request.MiniPig.BirthDate;
        minipig.Breed = request.MiniPig.Breed;
        minipig.IsVaccinated = request.MiniPig.IsVaccinated;
        minipig.IsSterilized = request.MiniPig.IsSterilized;
        minipig.Color = request.MiniPig.Color;
        minipig.MedicalHistory = request.MiniPig.MedicalHistory;
        minipig.PhotoUrl = request.MiniPig.PhotoUrl;
        minipig.ArrivalDate = request.MiniPig.ArrivalDate;
        minipig.Age = request.MiniPig.Age;
        minipig.Weight = request.MiniPig.Weight;

        _dataContext.MiniPigs.Update(minipig);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return minipig.IsnMiniPig;
    }
}
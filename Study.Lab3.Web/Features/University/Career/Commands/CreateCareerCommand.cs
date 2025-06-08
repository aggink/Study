using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheCareer.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheCareer.Commands;
=======
using Study.Lab3.Web.Features.University.Career.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Career.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Создание карьеры
/// </summary>
public sealed class CreateCareerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные карьеры
    /// </summary>
    [Required]
    [FromBody]
    public CreateCareerDto Career { get; init; }
}

public sealed class CreateCareerCommandHandler : IRequestHandler<CreateCareerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICareerService _careerService;

    public CreateCareerCommandHandler(
        DataContext dataContext,
        ICareerService careerService)
    {
        _dataContext = dataContext;
        _careerService = careerService;
    }

    public async Task<Guid> Handle(CreateCareerCommand request, CancellationToken cancellationToken)
    {
<<<<<<< HEAD
        var career = new Career
=======
        var career = new Storage.Models.University.Career
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            IsnCareer = Guid.NewGuid(),
            IsnStudent = request.Career.IsnStudent,
            IsnSubject = request.Career.IsnSubject,
            ParticipantsCount = request.Career.ParticipantsCount,
            CareerDate = request.Career.CareerDate
        };

        await _careerService.CreateOrUpdateCareerValidateAndThrowAsync(
            _dataContext, career, cancellationToken);

        await _dataContext.Career.AddAsync(career, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return career.IsnCareer;
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheSportclub.Commands;
=======
using Study.Lab3.Web.Features.University.Sportclub.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Sportclub.Commands;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Создание профкома
/// </summary>
public sealed class CreateSportclubCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные профкома
    /// </summary>
    [Required]
    [FromBody]
    public CreateSportclubDto Sportclub { get; init; }
}

public sealed class CreateSportclubCommandHandler : IRequestHandler<CreateSportclubCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ISportclubService _sportclubService;

    public CreateSportclubCommandHandler(
        DataContext dataContext,
        ISportclubService sportclubService)
    {
        _dataContext = dataContext;
        _sportclubService = sportclubService;
    }

    public async Task<Guid> Handle(CreateSportclubCommand request, CancellationToken cancellationToken)
    {
<<<<<<< HEAD
        var sportclub = new Sportclub
=======
        var sportclub = new Storage.Models.University.Sportclub
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
        {
            IsnSportclub = Guid.NewGuid(),
            IsnStudent = request.Sportclub.IsnStudent,
            IsnSubject = request.Sportclub.IsnSubject,
            ParticipantsCount = request.Sportclub.ParticipantsCount,
            SportclubDate = request.Sportclub.SportclubDate
        };

        await _sportclubService.CreateOrUpdateSportclubValidateAndThrowAsync(
            _dataContext, sportclub, cancellationToken);

        await _dataContext.Sportclub.AddAsync(sportclub, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sportclub.IsnSportclub;
    }
}
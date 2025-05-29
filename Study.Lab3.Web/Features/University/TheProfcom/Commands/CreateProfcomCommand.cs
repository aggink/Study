using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TheProfcom.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.Commands;

/// <summary>
/// Создание профкома
/// </summary>
public sealed class CreateProfcomCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные профкома
    /// </summary>
    [Required]
    [FromBody]
    public CreateProfcomDto Profcom { get; init; }
}

public sealed class CreateProfcomCommandHandler : IRequestHandler<CreateProfcomCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IProfcomService _profcomService;

    public CreateProfcomCommandHandler(
        DataContext dataContext,
        IProfcomService profcomService)
    {
        _dataContext = dataContext;
        _profcomService = profcomService;
    }

    public async Task<Guid> Handle(CreateProfcomCommand request, CancellationToken cancellationToken)
    {
        var teacherSubject = await _dataContext.TeacherSubjects
            .FirstOrDefaultAsync(x => x.IsnSubject == request.Profcom.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Научная встреча с идентификатором \"{request.Profcom.IsnSubject}\" не закреплена ни за одним преподавателем");

        var profcom = new Profcom
        {
            IsnProfcom = Guid.NewGuid(),
            IsnStudent = request.Profcom.IsnStudent,
            IsnSubject = request.Profcom.IsnSubject,
            ParticipantsCount = request.Profcom.ParticipantsCount,
            ProfcomDate = request.Profcom.ProfcomDate
        };

        await _profcomService.CreateOrUpdateProfcomValidateAndThrowAsync(
            _dataContext, profcom, teacherSubject.IsnTeacher, cancellationToken);

        await _dataContext.TheProfcom.AddAsync(profcom, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return profcom.IsnProfcom;
    }
}
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProfcom.Commands;

/// <summary>
/// Удаление профкома
/// </summary>
public sealed class DeleteProfcomCommand : IRequest
{
    /// <summary>
    /// Идентификатор профкома
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnProfcom { get; init; }
}

public sealed class DeleteProfcomCommandHandler : IRequestHandler<DeleteProfcomCommand>
{
    private readonly DataContext _dataContext;
    private readonly IProfcomService _profcomService;

    public DeleteProfcomCommandHandler(
        DataContext dataContext,
        IProfcomService profcomService)
    {
        _dataContext = dataContext;
        _profcomService = profcomService;
    }

    public async Task Handle(DeleteProfcomCommand request, CancellationToken cancellationToken)
    {
        var profcom = await _dataContext.TheProfcom
            .Include(x => x.Subject)
            .ThenInclude(x => x.TeacherSubjects)
            .FirstOrDefaultAsync(x => x.IsnProfcom == request.IsnProfcom, cancellationToken)
                ?? throw new BusinessLogicException($"Научной встречи с идентификатором \"{request.IsnProfcom}\" не существует");

        var teacherSubject = profcom.Subject.TeacherSubjects.FirstOrDefault()
            ?? throw new BusinessLogicException($"Научная встреча с идентификатором \"{profcom.IsnSubject}\" не закреплена ни за одним преподавателем");

        await _profcomService.CanDeleteAndThrowAsync(
            _dataContext, profcom, teacherSubject.IsnTeacher, cancellationToken);

        _dataContext.TheProfcom.Remove(profcom);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
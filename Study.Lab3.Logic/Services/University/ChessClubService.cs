using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ChessclubService : IChessclubService
{
    public async Task CreateOrUpdateChessclubValidateAndThrowAsync(
        DataContext dataContext,
        Chessclub Chessclub,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == Chessclub.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{Chessclub.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == Chessclub.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Данная деятельность с идентификатором \"{Chessclub.IsnSubject}\" не существует");
        }

        if (Chessclub.ParticipantsPip < ModelConstants.Chessclub.MinPersonValue || Chessclub.ParticipantsPip > ModelConstants.Chessclub.MaxPersonValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Chessclub.MinPersonValue} до {ModelConstants.Chessclub.MaxPersonValue}");
        }

        if (Chessclub.ChessclubDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingChessclub = await dataContext.Chessclub
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == Chessclub.IsnStudent &&
                x.IsnSubject == Chessclub.IsnSubject &&
                x.ChessclubDate.Date == Chessclub.ChessclubDate.Date &&
                x.IsnChessclub != Chessclub.IsnChessclub,
                cancellationToken);

        if (existingChessclub != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для соревнований по этому предмету в указанную дату");
        }

        if (Chessclub.IsnChessclub != Guid.Empty)
        {
            var originalChessclub = await dataContext.Chessclub
                .FirstOrDefaultAsync(x => x.IsnChessclub == Chessclub.IsnChessclub, cancellationToken);

            if (originalChessclub != null &&
                (DateTime.UtcNow - originalChessclub.ChessclubDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Chessclub Chessclub,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - Chessclub.ChessclubDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, проведенные более месяца назад");
        }

        var hasMeeting = await dataContext.Chessclub
            .AnyAsync(x =>
                x.IsnStudent == Chessclub.IsnStudent &&
                x.IsnSubject == Chessclub.IsnSubject &&
                x.ChessclubDate > Chessclub.ChessclubDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, так как уже есть более поздние встречи по предмету");
        }
    }
}
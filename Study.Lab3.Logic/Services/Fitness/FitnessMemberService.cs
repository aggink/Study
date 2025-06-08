using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Services.Fitness;

public class FitnessMemberService : IFitnessMemberService
{
    public async Task CreateOrUpdateMemberValidateAndThrowAsync(
        DataContext dataContext,
        FitnessMember member,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(member.SurName))
            throw new BusinessLogicException("Фамилия участника не может быть пустой");

        if (string.IsNullOrWhiteSpace(member.Name))
            throw new BusinessLogicException("Имя участника не может быть пустым");

        if (string.IsNullOrWhiteSpace(member.PhoneNumber))
            throw new BusinessLogicException("Номер телефона не может быть пустым");

        if (string.IsNullOrWhiteSpace(member.Email))
            throw new BusinessLogicException("Email не может быть пустым");

        if (!IsValidEmail(member.Email))
            throw new BusinessLogicException("Некорректный формат email");

        if (member.DateOfBirth >= DateTime.UtcNow.Date)
            throw new BusinessLogicException("Дата рождения не может быть в будущем");

        if (member.MembershipStartDate > member.MembershipEndDate)
            throw new BusinessLogicException("Дата начала членства не может быть позже даты окончания");

        // Проверка уникальности email и телефона
        var existingMemberWithEmail = await dataContext.Members
            .FirstOrDefaultAsync(x => x.Email == member.Email && x.IsnMember != member.IsnMember, cancellationToken);

        if (existingMemberWithEmail != null)
            throw new BusinessLogicException($"Участник с email \"{member.Email}\" уже существует");

        var existingMemberWithPhone = await dataContext.Members
            .FirstOrDefaultAsync(x => x.PhoneNumber == member.PhoneNumber && x.IsnMember != member.IsnMember,
                cancellationToken);

        if (existingMemberWithPhone != null)
            throw new BusinessLogicException($"Участник с номером телефона \"{member.PhoneNumber}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessMember member,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Members.AnyAsync(x => x.IsnMember == member.IsnMember, cancellationToken))
            throw new BusinessLogicException($"Участник с идентификатором \"{member.IsnMember}\" не существует");
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
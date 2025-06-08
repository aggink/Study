using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Services.Fitness;

public class FitnessTrainerService : IFitnessTrainerService
{
    public async Task CreateOrUpdateTrainerValidateAndThrowAsync(
        DataContext dataContext,
        FitnessTrainer trainer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(trainer.SurName))
            throw new BusinessLogicException("Фамилия тренера не может быть пустой");

        if (string.IsNullOrWhiteSpace(trainer.Name))
            throw new BusinessLogicException("Имя тренера не может быть пустым");

        if (string.IsNullOrWhiteSpace(trainer.PhoneNumber))
            throw new BusinessLogicException("Номер телефона не может быть пустым");

        if (string.IsNullOrWhiteSpace(trainer.Email))
            throw new BusinessLogicException("Email не может быть пустым");

        if (!IsValidEmail(trainer.Email))
            throw new BusinessLogicException("Некорректный формат email");

        if (trainer.ExperienceYears < 0)
            throw new BusinessLogicException("Опыт работы не может быть отрицательным");

        if (trainer.HourlyRate <= 0)
            throw new BusinessLogicException("Почасовая ставка должна быть больше нуля");

        // Проверка уникальности email и телефона
        var existingTrainerWithEmail = await dataContext.Trainers
            .FirstOrDefaultAsync(x => x.Email == trainer.Email && x.IsnTrainer != trainer.IsnTrainer, cancellationToken);

        if (existingTrainerWithEmail != null)
            throw new BusinessLogicException($"Тренер с email \"{trainer.Email}\" уже существует");

        var existingTrainerWithPhone = await dataContext.Trainers
            .FirstOrDefaultAsync(x => x.PhoneNumber == trainer.PhoneNumber && x.IsnTrainer != trainer.IsnTrainer, cancellationToken);

        if (existingTrainerWithPhone != null)
            throw new BusinessLogicException($"Тренер с номером телефона \"{trainer.PhoneNumber}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessTrainer trainer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Trainers.AnyAsync(x => x.IsnTrainer == trainer.IsnTrainer, cancellationToken))
            throw new BusinessLogicException($"Тренер с идентификатором \"{trainer.IsnTrainer}\" не существует");
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
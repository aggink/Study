using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Extensions.University;

/// <summary>
/// Расширения для модели <see cref="Teacher"/>
/// </summary>
public static class TeacherExtensions
{
    /// <summary>
    /// Получить ФИО учителя
    /// </summary>
    /// <param name="teacher">Учитель</param>
    /// <returns>ФИО учителя</returns>
    public static string GetFio(this Teacher teacher)
    {
        return string.Join(" ", (new string[]
        {
            teacher.SurName,
            teacher.Name,
            teacher.PatronymicName
        }).Where(x => !string.IsNullOrEmpty(x)));
    }
}
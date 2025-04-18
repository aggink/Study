using Lab3.Storage.Models.University;

namespace Lab3.Logic.Extensions.University
{
    public static class StudentExtensions
    {
        /// <summary>
        /// Получить ФИО студента
        /// </summary>
        /// <param name="student">Студент</param>
        /// <returns>ФИО студента</returns>
        public static string GetFio(this Student student)
        {
            return string.Join(" ", (new string[]
            {
                student.SurName,
                student.Name,
                student.PatronymicName
            }).Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}

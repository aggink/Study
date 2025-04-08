using CoreLib.Utilities.Interfaces.DtoModels.Services;

namespace CoreLib.Utilities.Interfaces.Services
{
    public interface IWorksheetReaderService
    {
        /// <summary>
        /// Получить таблицу из файла Excel
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Таблица из файла</returns>
        /// <remarks>
        /// Работает только на Windows. Требуется установленный Microsoft Excel.
        /// </remarks>
        /// <example>
        /// Структура таблицы: Column1 | Column2 | Column3 | Column4 | Column5. Первая строка заголовки.
        /// </example>
        List<WorksheetDto> LoadFromExcel(string filePath);
    }
}

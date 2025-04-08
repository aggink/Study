namespace CoreLib.Utilities.Interfaces.Services
{
    public interface IExcelDataProcessorService
    {
        /// <summary>
        /// Загружает данные из Excel-файла, очищает значения в колонке 4 от лишних пробелов, 
        /// удаляет дубликаты и сохраняет уникальные значения в новый текстовый файл
        /// </summary>
        /// <param name="inputFilePath">Путь к исходному Excel-файлу, из которого будут извлечены данные</param>
        /// <param name="outputFilePath">Путь к текстовому файлу, в который будут записаны уникальные данные</param>
        void ExportUniqueData(string inputFilePath, string outputFilePath);
    }
}

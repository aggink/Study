using System.Text.RegularExpressions;

namespace CoreLib.Utilities.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Удаляет лишние пробельные символы в строке:
        /// заменяет все виды пробелов, табуляции и переводов строк на один пробел,
        /// а также обрезает пробелы в начале и в конце строки.
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <returns>Очищенная строка с нормализованными пробелами</returns>
        public static string CleanWhitespace(this string input)
        {
            return Regex.Replace(input ?? string.Empty, @"\s+", " ").Trim();
        }
    }
}

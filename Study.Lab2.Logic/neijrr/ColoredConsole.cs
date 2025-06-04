namespace Study.Lab2.Logic.neijrr
{
    public static class ColoredConsole
    {
        /// <summary>
        /// Написать в консоль указанным цветом
        /// </summary>
        /// <param name="value">Записываемое значение</param>
        /// <param name="color">Цвет текста</param>
        /// <remarks>
        /// Является обвёрткой для функций в Console
        /// </remarks>
        public static void WriteLine(string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}

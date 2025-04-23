namespace Study.Lab1.Logic.neijrr
{
    /// <summary>
    /// Утилитарный класс для математических операций
    /// </summary>
    public sealed class MathHelper
    {
        /// <summary>
        /// Находит наибольший общий делитель
        /// </summary>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}

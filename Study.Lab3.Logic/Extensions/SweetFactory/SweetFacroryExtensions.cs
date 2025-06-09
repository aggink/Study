namespace Study.Lab3.Logic.Extensions.SweetFactory
{
    /// <summary>
    /// Нахождение,находящихся в России, фабрики
    /// </summary>
    public static class SweetFactoryExtensions
    {
        /// <summary>
        /// Получить фабрики с Российским адресом 
        /// </summary>
        /// <param name="factory">Фабрики</param>
        /// <returns>Название фабрики</returns>
        public static bool IsAddressCorrect(this Storage.Models.Sweets.SweetFactory sweetfactory)
        {
            return sweetfactory.Address.Contains("Russian Federation");
        }
    }
}

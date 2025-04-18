using Lab3.Logic.Interfaces.Services.University;
using Lab3.Logic.Services.University;
using Microsoft.Extensions.DependencyInjection;

namespace Lab3.Logic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрация сервисов библиотеки Logic
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public static void AddLogicServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IGroupService, GroupService>();
        }
    }
}

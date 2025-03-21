namespace Study.Lab2.Logic.Interfaces
{
    public interface IRunService : IDisposable
    {
        /// <summary>
        /// Запуск выполнения задания
        /// </summary>
        void RunTask();

        /// <summary>
        /// Запуск выполнения задания
        /// </summary>
        Task RunTaskAsync();
    }
}

using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public class Task17 : IRunnable
{
    // Событие для синхронизации между потоками
    private static readonly AutoResetEvent userInputEvent = new AutoResetEvent(false);
    private static volatile bool isRunning = true;

    public void Run()
    {
        Console.WriteLine("Приложение запущено. Нажимайте Enter для вывода сообщения.");
        Console.WriteLine("Для выхода введите 'exit' и нажмите Enter.");

        // Запускаем поток из пула потоков
        ThreadPool.QueueUserWorkItem(MessageLoop);

        // Основной цикл обработки ввода пользователя
        while (isRunning)
        {
            var input = Console.ReadLine();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                isRunning = false;
                userInputEvent.Set(); // Пробуждаем поток для завершения
                break;
            }

            // Пробуждаем поток для вывода сообщения
            userInputEvent.Set();
        }

        Console.WriteLine("Приложение завершает работу...");
    }

    private static void MessageLoop(object state)
    {
        while (isRunning)
        {
            // Ожидаем сигнала от пользователя
            userInputEvent.WaitOne();

            if (!isRunning) break;

            // Выводим сообщение
            Console.WriteLine($"[Поток {Thread.CurrentThread.ManagedThreadId}] Вы нажали Enter в {DateTime.Now:T}");
        }
    }
}

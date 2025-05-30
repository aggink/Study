using Study.Example.Interfaces;
using Study.Example.Tasks;

var task = "Task1";

IRunnable runnable = task switch
{
    nameof(Task1) => new Task1(),
    _ => throw new NotImplementedException()
};

runnable.Run();

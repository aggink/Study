using Study.Example.Interfaces;
using Study.Example.Tasks;

var task = "Task1";

IRunnable runnable = task switch
{
    nameof(Task1) => new Task1(),
    nameof(Task2) => new Task2(),
    nameof(Task3) => new Task3(),
    nameof(Task4) => new Task4(),
    nameof(Task5) => new Task5(),
    nameof(Task6) => new Task6(),
    nameof(Task7) => new Task7(),
    nameof(Task8) => new Task8(),
    nameof(Task9) => new Task9(),
    nameof(Task10) => new Task10(),
    nameof(Task11) => new Task11(),
    nameof(Task12) => new Task12(),
    nameof(Task13) => new Task13(),
    _ => null
};

runnable?.Run();

IRunnableAsync runnable2 = task switch
{
    nameof(Task14) => new Task14(),
    _ => null
};

await runnable2?.RunAsync();
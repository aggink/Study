using Study.Example.Interfaces;

namespace Study.Example.Tasks;

public interface IVehicle
{
    double GetSpeed();
}

public class Car : IVehicle
{
    public double MaxSpeed { get; private set; }

    public Car(double maxSpeed)
    {
        MaxSpeed = maxSpeed;
    }

    public double GetSpeed()
    {
        return MaxSpeed;
    }

    public override string ToString()
    {
        return $"Car, максимальная скорость: {MaxSpeed}";
    }
}

public class Bicycle : IVehicle
{
    public double MaxSpeed { get; private set; }

    public Bicycle(double maxSpeed)
    {
        MaxSpeed = maxSpeed;
    }

    public double GetSpeed()
    {
        return MaxSpeed;
    }

    public override string ToString()
    {
        return $"Bicycle, максимальная скорость: {MaxSpeed}";
    }
}

public class Task6 : IRunnable
{
    public void Run()
    {
        var random = new Random();
        var vehicles = new List<IVehicle>();

        for (var i = 0; i < 10; i++)
        {
            if (random.Next(2) == 0)
            {
                vehicles.Add(new Car(random.Next(30, 121)));
            }
            else
            {
                vehicles.Add(new Bicycle(random.Next(10, 61)));
            }
        }

        Console.WriteLine("\nТранспортные средства:");
        Console.WriteLine(string.Join("\n", vehicles));

        var fastVehicles = vehicles
            .Where(x => x.GetSpeed() > 50)
            .OrderByDescending(x => x.GetSpeed())
            .ToList();

        Console.WriteLine("\nТранспорт со скоростью > 50, отсортированный по убыванию");
        Console.WriteLine(string.Join("\n", fastVehicles));
    }
}

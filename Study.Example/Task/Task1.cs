using Study.Example.Interfaces;

namespace Study.Example.Task1;

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }

    public override string ToString()
    {
        return $"{City}, ул. {Street}";
    }
}

public class Person
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Person(string name, string city, string street)
    {
        Name = name;
        Address = new Address
        {
            City = city,
            Street = street
        };
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Адрес: {Address}";
    }
}


public class Task1 : IRunnable
{
    private readonly string[] _names = { "Алексей", "Мария", "Иван", "Ольга", "Николай", "Татьяна" };
    private readonly string[] _cities = { "Москва", "Санкт-Петербург", "Казань", "Новосибирск", "Екатеринбург" };
    private readonly string[] _streets = { "Ленина", "Советская", "Мира", "Пушкина", "Гагарина" };

    public void Run()
    {
        Console.Write("Введите количество человек: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некорректное число.");
            return;
        }

        var rnd = new Random();
        var people = new Person[n];

        for (int i = 0; i < n; i++)
        {
            var randomName = _names[rnd.Next(_names.Length)];
            var randomCity = _cities[rnd.Next(_cities.Length)];
            var randomStreet = _streets[rnd.Next(_streets.Length)];

            people[i] = new Person(randomName, randomCity, randomStreet);
        }

        Console.WriteLine("\nСписок людей:");
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}

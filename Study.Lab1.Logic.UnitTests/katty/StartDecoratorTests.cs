using Study.Lab1.Logic.katty.Task_2;

namespace Study.Lab1.Logic.UnitTests.katty;

[TestFixture]
public class StartDecoratorTests
{
    [Test]
    public void FormatDateTime_ShouldAdd_PrefixToFormattedDate()
    {
        // Arrange
        var baseFormatter = new EuropeanDateTimeFormatter();
        var decorator = new StartDecorator(baseFormatter, "Начало: ");
        var dateTime = new DateTime(2023, 1, 1);

        // Act
        var result = decorator.FormatDateTime(dateTime);

        // Assert
        // Либо принимаем оба варианта (с нулем и без)
        Assert.That(result, Is.EqualTo("Начало: 01.01.2023 00:00:00").Or.EqualTo("Начало: 01.01.2023 0:00:00"));

        // Либо проверяем только начало строки
        Assert.That(result, Does.StartWith("Начало: 01.01.2023"));
        Assert.That(result, Does.EndWith(":00:00"));
    }
}
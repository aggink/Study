using Study.Lab1.Logic.neijrr.Task2;
using System.Globalization;

namespace Study.Lab1.Logic.UnitTests.neijrr.Task2;

[TestFixture]
public class EuropeanDateTimeFormatterTests
{
    [Test]
    public void CorrectValue()
    {
        // Условие
        var culture = new CultureInfo("de-DE");
        var formatter = new EuropeanDateTimeFormatter();

        // Действие
        var currentTime = formatter.DateTime();
        var epochTime = formatter.DateTime(DateTime.UnixEpoch);

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(currentTime, Is.EqualTo(DateTime.Now.ToString(culture)), "Неверные дата и/или время для текущего времени");
            Assert.That(epochTime, Is.EqualTo(DateTime.UnixEpoch.ToString(culture)), "Неверные дата и/или время для указанного времени");
        });
    }

    [Test]
    public void CorrectFormat()
    {
        // Формат даты: dd.mm.yyyy HH:MM:SS

        // Условие
        var formatter = new EuropeanDateTimeFormatter();

        // Действие
        var datetime = formatter.DateTime();
        var date = formatter.Date();
        var time = formatter.Time();
        var shortTime = formatter.Time(includeSeconds: false);

        // Проверка
        // - Пустая строка
        Assert.Multiple(() =>
        {
            Assert.That(datetime, Is.Not.Empty, "DateTime вернул пустую строку");
            Assert.That(date, Is.Not.Empty, "Date вернул пустую строку");
            Assert.That(time, Is.Not.Empty, "Time вернул пустую строку");
            Assert.That(shortTime, Is.Not.Empty, "Time без секунд вернул пустую строку");
        });
        // - Правильность формата
        Assert.Multiple(() =>
        {
            Assert.That(datetime, Does.Match(@"\d{1,2}\.\d{2}\.\d{4} \d{1,2}:\d{2}:\d{2}"), "Несоответствует формат DateTime");
            Assert.That(date, Does.Match(@"\d{1,2}\.\d{2}\.\d{4}"), "Несоответствует формат Date");
            Assert.That(time, Does.Match(@"\d{1,2}:\d{2}:\d{2}"), "Несоответствует формат Time");
            Assert.That(time, Does.Match(@"\d{1,2}:\d{2}"), "Несоответствует формат Time без секунд");
        });
    }

    [Test]
    public void Prefix()
    {
        // Условие
        var formatter = new EuropeanDateTimeFormatter();
        var prefix = "Prefix ";
        var decoratedFormatter = new PrefixDecorator(formatter, prefix);

        // Действие
        Dictionary<string, string> results = [];
        results.Add("DateTime", decoratedFormatter.DateTime());
        results.Add("Date", decoratedFormatter.Date());
        results.Add("Time", decoratedFormatter.Time());
        results.Add("Time без секунд", decoratedFormatter.Time(includeSeconds: false));

        // Проверка
        Assert.Multiple(() =>
        {
            foreach (var item in results)
                Assert.That(item.Value, Does.StartWith(prefix), $"Нет префикса в {item.Key}");
        });
    }

    [Test]
    public void Suffix()
    {
        // Условие
        var formatter = new EuropeanDateTimeFormatter();
        var suffix = " suffix";
        var decoratedFormatter = new SuffixDecorator(formatter, suffix);

        // Действие
        Dictionary<string, string> results = [];
        results.Add("DateTime", decoratedFormatter.DateTime());
        results.Add("Date", decoratedFormatter.Date());
        results.Add("Time", decoratedFormatter.Time());
        results.Add("Time без секунд", decoratedFormatter.Time(includeSeconds: false));

        // Проверка
        Assert.Multiple(() =>
        {
            foreach (var item in results)
                Assert.That(item.Value, Does.EndWith(suffix), $"Нет суффикса в {item.Key}");
        });
    }

    [Test]
    public void MultipleDecorators()
    {
        // Условие
        var formatter = new EuropeanDateTimeFormatter();
        var prefix = "[";
        var suffix = "]";
        // Prefix -> Suffix
        var psFormatter = new SuffixDecorator(new PrefixDecorator(formatter, prefix), suffix);
        // Suffix -> Prefix
        var spFormatter = new PrefixDecorator(new SuffixDecorator(formatter, suffix), prefix);

        // Действие
        Dictionary<string, string> psResults = [];
        psResults.Add("DateTime", psFormatter.DateTime());
        psResults.Add("Date", psFormatter.Date());
        psResults.Add("Time", psFormatter.Time());
        psResults.Add("Time без секунд", psFormatter.Time(includeSeconds: false));

        Dictionary<string, string> spResults = [];
        spResults.Add("DateTime", spFormatter.DateTime());
        spResults.Add("Date", spFormatter.Date());
        spResults.Add("Time", spFormatter.Time());
        spResults.Add("Time без секунд", spFormatter.Time(includeSeconds: false));

        // Проверка
        // - Проверка декораторов
        Assert.Multiple(() =>
        {
            // Наличие префикса
            foreach (var item in psResults)
                Assert.That(item.Value, Does.StartWith(prefix), $"Нет префикса в {item.Key} (p->s)");

            foreach (var item in spResults)
                Assert.That(item.Value, Does.StartWith(prefix), $"Нет префикса в {item.Key} (s->p)");

            // Наличие суффикса
            foreach (var item in psResults)
                Assert.That(item.Value, Does.EndWith(suffix), $"Нет суффикса в {item.Key} (p->s)");

            foreach (var item in spResults)
                Assert.That(item.Value, Does.EndWith(suffix), $"Нет суффикса в {item.Key} (s->p)");
        });
        // - Проверка независимости от порядка
        Assert.Multiple(() =>
        {
            foreach (var item in psResults)
                Assert.That(
                    item.Value, Is.EqualTo(spResults[item.Key]),
                    $"Не совпадает результат p->s и s->p для {item.Key}"
                );
        });
    }
}

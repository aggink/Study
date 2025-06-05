using Study.Lab2.Logic.neijrr;

namespace Study.Lab2.Logic.UnitTests.neijrr;

[TestFixture]
public class UrlBuilderTests
{
    [Test]
    public void UrlBuilder()
    {
        // Условие
        var urlBuilder = new UrlBuilder(ApiTestData.JsonPlaceholder_URL);

        // Действие
        var baseUrlProperty = urlBuilder.BaseUrl;
        var baseUrlFunc = urlBuilder.Url();
        var postZeroUrl = urlBuilder.Url(["posts", 0]);
        var postsFromUserUrl = urlBuilder.Url(["posts"], parameters: new() { { "userId", 0 } });
        var httpUrl = urlBuilder.Url(protocol: "http");

        // Проверка
        Assert.Multiple(() =>
        {
            Assert.That(baseUrlProperty, Is.EqualTo(ApiTestData.JsonPlaceholder_URL), "Неправильно сохранён базовый Url");
            Assert.That(baseUrlFunc, Is.EqualTo(ApiTestData.JsonPlaceholder_URL), "Функция Url() не возвращает базовый Url");
            Assert.That(postZeroUrl, Is.EqualTo($"{ApiTestData.JsonPlaceholder_URL}posts/0/"), "Неправильно составлен URL при указанном пути");
            Assert.That(postsFromUserUrl, Is.EqualTo($"{ApiTestData.JsonPlaceholder_URL}posts?userId=0"), "Неправильно составлен URL с опциями");
            Assert.That(httpUrl, Is.EqualTo($"http://jsonplaceholder.typicode.com/"), "Неправильно составлен URL с альтернативным протоколом");
        });
    }
}

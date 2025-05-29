namespace Study.Lab2.Logic.UnitTests.PresvyatoyKabachok;

[TestFixture]
public class RequestServiceTests
{
    [Test]
    public void FetchData_ReturnsContent_On200()
    {
        using var svc = new RequestService(CreateClient(HttpStatusCode.OK, "{\"x\":1}"));
        Assert.That(svc.FetchData("http://any"), Is.EqualTo("{\"x\":1}"));
    }

    [Test]
    public void FetchData_Throws_OnNonSuccess()
    {
        using var svc = new RequestService(CreateClient(HttpStatusCode.BadRequest, reason: "Bad"));
        Assert.Throws<Exception>(() => svc.FetchData("http://any"));
    }

    [Test]
    public async Task FetchDataAsync_ReturnsContent_On200()
    {
        using var svc = new RequestService(CreateClient(HttpStatusCode.OK, "ok"));
        var data = await svc.FetchDataAsync("http://any");
        Assert.That(data, Is.EqualTo("ok"));
    }

    [Test]
    public void FetchDataAsync_Throws_OnNonSuccess()
    {
        using var svc = new RequestService(CreateClient(HttpStatusCode.InternalServerError));
        Assert.ThrowsAsync<Exception>(async () => await svc.FetchDataAsync("http://any"));
    }

    private static HttpClient CreateClient(HttpStatusCode code, string content = "", string reason = "Error")
    {
        var handler = new Mock<HttpMessageHandler>();
        handler.Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.IsAny<HttpRequestMessage>(),
                   ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = code,
                   ReasonPhrase = reason,
                   Content = new StringContent(content)
               });

        return new HttpClient(handler.Object);
    }
}

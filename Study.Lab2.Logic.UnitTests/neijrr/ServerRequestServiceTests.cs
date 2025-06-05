using Study.Lab2.Logic.Interfaces.neijrr;
using Study.Lab2.Logic.neijrr;

namespace Study.Lab2.Logic.UnitTests.neijrr;

[TestFixture]
public class ServerRequestServiceTests
{
    [Test]
    public void GetPost()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        IPost post = serverRequestService.GetPost(1);

        // Проверка
        Assert.That(post.ToString(), Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One_Pretty));
    }

    [Test]
    public async Task GetPostAsync()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        IPost post = await serverRequestService.GetPostAsync(1);

        // Проверка
        Assert.That(post.ToString(), Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One_Pretty));
    }

    [Test]
    public void SendPost()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        int response = serverRequestService.SendPost(
            ApiTestData.ServerRequestService_UserID,
            ApiTestData.ServerRequestService_NewPostTitle,
            ApiTestData.ServerRequestService_NewPostBody
        );

        // Проверка
        Assert.That(response, Is.EqualTo(ApiTestData.ServerRequestService_NewPostID));
    }


    [Test]
    public async Task SendPostAsync()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        int response = await serverRequestService.SendPostAsync(
            ApiTestData.ServerRequestService_UserID,
            ApiTestData.ServerRequestService_NewPostTitle,
            ApiTestData.ServerRequestService_NewPostBody
        );

        // Проверка
        Assert.That(response, Is.EqualTo(ApiTestData.ServerRequestService_NewPostID));
    }

    [Test]
    public void UpdatePost()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        IPost post = serverRequestService.UpdatePost(1);

        // Проверка
        Assert.That(post.ToString(), Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One_Pretty));
    }

    [Test]
    public async Task UpdatePostAsync()
    {
        // Условие
        var serverRequestService = new ServerRequestService(ApiTestData.JsonPlaceholder_URL);

        // Действие
        IPost post = await serverRequestService.UpdatePostAsync(1);

        // Проверка
        Assert.That(post.ToString(), Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One_Pretty));
    }
}

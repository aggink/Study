using Moq;
using NUnit.Framework;
using Study.Lab2.Logic.Interfaces.mansurgh;
using Study.Lab2.Logic.Interfaces.mansurgh.DtoModels;
using Study.Lab2.Logic.mansurgh;
using System.Threading;
using System.Threading.Tasks;

namespace Study.Lab2.Logic.UnitTests.mansurgh;

[TestFixture]
public class mansurghServiceTests
{
    [Test]
    public void RunTask_CallsFetchDataThreeTimes()
    {
        // Arrange
        var mockRequest = new Mock<IRequestService>();
        mockRequest
            .Setup(x => x.FetchData(It.IsAny<string>()))
            .Returns(new HttpResponseDto { StatusCode = 200, Text = "{}" });

        var service = new mansurghServiceTestable(mockRequest.Object);

        // Act
        service.RunTask();

        // Assert
        mockRequest.Verify(x => x.FetchData(It.IsAny<string>()), Times.Exactly(3));
    }

    [Test]
    public async Task RunTaskAsync_CallsFetchDataAsyncThreeTimes()
    {
        // Arrange
        var mockRequest = new Mock<IRequestService>();
        mockRequest
            .Setup(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseDto { StatusCode = 200, Text = "{}" });

        var service = new mansurghServiceTestable(mockRequest.Object);

        // Act
        await service.RunTaskAsync();

        // Assert
        mockRequest.Verify(x => x.FetchDataAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
    }

    // Подкласс для тестирования с внедрением зависимостей
    private class mansurghServiceTestable : mansurghService
    {
        public mansurghServiceTestable(IRequestService injectedHandler)
        {
            typeof(mansurghService)
                .GetField("_requestHandler", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .SetValue(this, injectedHandler);

            typeof(mansurghService)
                .GetMethod("SetupApis", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                .Invoke(this, null);
        }
    }
}

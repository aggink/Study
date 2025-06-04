using Study.Lab2.Logic.neijrr;

namespace Study.Lab2.Logic.UnitTests.neijrr
{
    [TestFixture]
    public class ResponseProcessorTests
    {
        [Test]
        public void ToJson()
        {
            // Условие
            var responseProcessor = new ResponseProcessor();

            // Действие
            var response = responseProcessor.ToJsonString(ApiTestData.JsonPlaceholder_Post_One);
            var prettyResponse = responseProcessor.ToJsonString(ApiTestData.JsonPlaceholder_Post_One, true);

            // Проверка
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One), "Результат не совпадает с сообщением");
                Assert.That(prettyResponse, Is.EqualTo(ApiTestData.JsonPlaceholder_Post_One_Pretty), "Ошибка форматирования JSON");
            });
        }

        [Test]
        public void GetErrorMessage_NoError()
        {
            // Условие
            var responseProcessor = new ResponseProcessor();

            // Действие
            var response = responseProcessor.GetErrorMessage(ApiTestData.JsonPlaceholder_Post_One);
            var prettyResponse = responseProcessor.GetErrorMessage(ApiTestData.JsonPlaceholder_Post_One_Pretty);

            // Проверка
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Null, "Обнаружена ошибка в ответе без ошибки");
                Assert.That(prettyResponse, Is.Null, "Обнаружена ошибка в форматированном ответе без ошибки");
            });
        }

        [Test]
        public void GetErrorMessage_RegularError()
        {
            // Условие
            var responseProcessor = new ResponseProcessor();

            // Действие
            var response = responseProcessor.GetErrorMessage(ApiTestData.ResponseProcessor_TestErrorResponse);
            var complexResponse = responseProcessor.GetErrorMessage(ApiTestData.ResponseProcessor_TestComplexErrorResponse);

            // Проверка
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null, "Не обнаружена ошибка в ответе с ошибкой");
                Assert.That(complexResponse, Is.Not.Null, "Не обнаружена ошибка в ответе с комплексной ошибкой");
            });
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.EqualTo(ApiTestData.ResponseProcessor_ErrorMessage), "Не совпадает ошибка в JSON и полученная ошибка");
                Assert.That(complexResponse, Is.EqualTo(ApiTestData.ResponseProcessor_ErrorMessage), "Не совпадает ошибка в комплексном JSON и полученная ошибка");
            });
        }

        [Test]
        public void GetErrorMessage_ParsingError()
        {
            // Условие
            var responseProcessor = new ResponseProcessor();

            // Действие
            var response = responseProcessor.GetErrorMessage(ApiTestData.ResponseProcessor_TestInvalidResponse);

            // Проверка
            Assert.That(response, Is.EqualTo("Ошибка при парсинге ответа"), "Не обнаружена ошибка при парсинге");
        }
    }
}

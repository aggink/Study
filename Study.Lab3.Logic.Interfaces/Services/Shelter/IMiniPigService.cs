using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Interfaces.Services.Shelter;

public interface IMiniPigService
{
	/// <summary>
	/// Проверка модели мини пига на возможность создания или редактирования
	/// </summary>
	/// <param name="dataContext">Контекст базы данных</param>
	/// <param name="minipig">Мини пиг</param>
	/// <param name="cancellationToken">Токен отмены</param>
	Task CreateOrUpdateMiniPigValidateAndThrowAsync(
		DataContext dataContext,
		MiniPig minipig,
		CancellationToken cancellationToken = default);
}

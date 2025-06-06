﻿using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Interfaces.Services.BeautySalon;

public interface IBeautyServiceService
{
    /// <summary>
    /// Проверка услуги на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyservice">Услуга салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateBeautyServiceValidateAndThrowAsync(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка услуги на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyservice">Услуга салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default);
}

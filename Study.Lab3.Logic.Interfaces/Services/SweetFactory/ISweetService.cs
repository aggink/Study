﻿using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Interfaces.Services.SweetFactory
{
    public interface ISweetService
    {
        /// <summary>
        /// Проверка модели таблицы Сладости на возможность создания или редактирования
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="sweet">Сладости</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CreateOrUpdateSweetValidateAndThrowAsync(
            DataContext dataContext,
            Sweet sweet,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка возможности удаления записи
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="sweet">Сладости</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            Sweet sweet,
            CancellationToken cancellationToken = default);
    }
}

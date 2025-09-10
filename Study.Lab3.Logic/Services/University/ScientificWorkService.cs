using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University
{
    public sealed class ScientificWorkService : IScientificWorkService
    {
        public async Task CreateOrUpdateScientificWorkValidateAndThrowAsync(
            DataContext dataContext,
            ScientificWork scientificWork,
            CancellationToken cancellationToken = default)
        {
            if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == scientificWork.IsnStudent, cancellationToken))
            {
                throw new BusinessLogicException($"Студент с идентификатором \"{scientificWork.IsnStudent}\" не существует");
            }

            if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == scientificWork.IsnSubject, cancellationToken))
            {
                throw new BusinessLogicException($"Предмет с идентификатором \"{scientificWork.IsnSubject}\" не существует");
            }

            if (scientificWork.PageCount < ModelConstants.ScientificWork.MinPageCount ||
                scientificWork.PageCount > ModelConstants.ScientificWork.MaxPageCount)
            {
                throw new BusinessLogicException($"Количество страниц должно быть от {ModelConstants.ScientificWork.MinPageCount} до {ModelConstants.ScientificWork.MaxPageCount}");
            }

            if (scientificWork.PublicationDate > DateTime.UtcNow)
            {
                throw new BusinessLogicException("Дата публикации не может быть в будущем");
            }

            var existingWork = await dataContext.ScientificWorks
                .FirstOrDefaultAsync(x =>
                    x.IsnStudent == scientificWork.IsnStudent &&
                    x.IsnSubject == scientificWork.IsnSubject &&
                    x.Title == scientificWork.Title &&
                    x.IsnScientificWork != scientificWork.IsnScientificWork,
                    cancellationToken);

            if (existingWork != null)
            {
                throw new BusinessLogicException("Студент уже имеет научную работу с таким названием по этому предмету");
            }
        }

        public async Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            ScientificWork scientificWork,
            CancellationToken cancellationToken = default)
        {
            if ((DateTime.UtcNow - scientificWork.PublicationDate).TotalDays > 365)
            {
                throw new BusinessLogicException("Нельзя удалить научную работу, опубликованную более года назад");
            }

            //var hasReferences = await dataContext.WorkReferences
             //   .AnyAsync(x => x.IsnScientificWork == scientificWork.IsnScientificWork,
             //       cancellationToken);

            //if (hasReferences)
            //{
            //    throw new BusinessLogicException("Нельзя удалить научную работу, на которую есть ссылки в других работах");
            //}
        }

    }
}
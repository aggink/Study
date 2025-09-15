using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University
{
    public interface IScientificWorkService
    {
        Task CreateOrUpdateScientificWorkValidateAndThrowAsync(
            DataContext dataContext,
            ScientificWork scientificWork,
            CancellationToken cancellationToken = default);

        Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            ScientificWork scientificWork,
            CancellationToken cancellationToken = default);
    }
}
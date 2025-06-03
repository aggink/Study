using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Shelter;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Services.Shelter;

public class AdoptionService : IAdoptionService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        Adoption adoption,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ShelterCustomers.AnyAsync(
                x =>  x.IsnCustomer == adoption.CustomerIsn,
                cancellationToken))
        {
            throw new BusinessLogicException($"Клиент с идентификатором \"{adoption.CustomerIsn}\" не найден");
        }
        
        if (!await dataContext.Cats.AnyAsync(
                x => x.IsnCat == adoption.CatIsn,
                cancellationToken))
        {
            throw new BusinessLogicException($"Кот с идентификатором \"{adoption.CatIsn}\" не найден");
        }
    }


    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Adoption adoption,
        CancellationToken cancellationToken = default)
    {
        if(!await dataContext.Adoptions.AnyAsync(
                x => x.IsnAdoption == adoption.IsnAdoption,
                cancellationToken))
        {
            throw new BusinessLogicException($"Невозможно удалить: усыновление с идентификатором \"{adoption.IsnAdoption}\" не найдено");
        }
    }
}
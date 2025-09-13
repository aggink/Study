using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PoliceDepartament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;

public interface IOfficerService
{
    Task CreateOrUpdateGroupValidateAndThrowAsync(
    DataContext dataContext,
    Officer officer,
    CancellationToken cancellationToken = default);
}

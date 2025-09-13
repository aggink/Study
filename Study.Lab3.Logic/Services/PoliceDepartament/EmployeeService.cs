using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PoliceDepartament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Services.PoliceDepartament;

public class EmployeeService : IEmployeeService
{   
    public async Task CreateOrUpdateGroupValidateAndThrowAsync(
    DataContext dataContext,
    Employee employee,
    CancellationToken cancellationToken = default)
    {
        if (await dataContext.Employees.AnyAsync(x => x.IsnEmployee != employee.IsnEmployee && x.Name == employee.Name, cancellationToken))
            throw new BusinessLogicException($"Работник с именем \"{employee.Name}\" уже создан");
    }
}

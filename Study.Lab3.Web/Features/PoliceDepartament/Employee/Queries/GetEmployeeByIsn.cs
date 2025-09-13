using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.Queries;

public sealed class GetEmployeeByIsnQuery : IRequest<EmployeeDto>
{
    [Required]
    [FromQuery]
    public Guid IsnEmployee { get; init; }
}

public sealed class GetEmployeeByIsnQueryHandler : IRequestHandler<GetEmployeeByIsnQuery, EmployeeDto>
{
    private readonly DataContext _dataContext;

    public GetEmployeeByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeByIsnQuery request, CancellationToken cancellationToken)
    {
        var employee = await _dataContext.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnEmployee == request.IsnEmployee, cancellationToken)
                ?? throw new BusinessLogicException($"Работника с идентификатором \"{request.IsnEmployee}\" не существует");

        return new EmployeeDto
        {
            IsnEmployee = employee.IsnEmployee,
            Name = employee.Name,
            SurName = employee.SurName,
            Work = employee.Work
        };
    }
}


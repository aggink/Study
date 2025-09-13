using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.Commands;

public sealed class UpdateEmployeeCommand : IRequest<Guid>
{
    [Required]
    [FromBody]
    public UpdateEmployeeDto Employee { get; init; }
}

public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IEmployeeService _employeeService;
    public UpdateEmployeeCommandHandler(DataContext dataContext, IEmployeeService employeeService)
    {
        _dataContext = dataContext;
        _employeeService = employeeService;
    }
    public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dataContext.Employees.FirstOrDefaultAsync(x => x.IsnEmployee == request.Employee.IsnEmployee, cancellationToken)
        ?? throw new BusinessLogicException($"Работника с идентификатором \"{request.Employee.IsnEmployee}\" не существует");

        employee.Name = request.Employee.Name;
        employee.SurName = request.Employee.SurName;
        employee.Work = request.Employee.Work;

        await _employeeService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, employee, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return employee.IsnEmployee;
    }
}

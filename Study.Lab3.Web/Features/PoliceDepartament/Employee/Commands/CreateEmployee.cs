using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.Commands;

public sealed class CreateEmployeeCommand : IRequest<Guid>
{
    [FromBody]
    [Required]
    public CreateEmployeeDto Employee { get; init; }
}
public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IEmployeeService _employeeService;
    public CreateEmployeeCommandHandler(DataContext dataContext, IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        _dataContext = dataContext;
    }
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Storage.Models.PoliceDepartament.Employee
        {
            IsnEmployee = Guid.NewGuid(),
            Name = request.Employee.Name,
            SurName = request.Employee.SurName,
            Work = request.Employee.Work
        };

        await _employeeService.CreateOrUpdateGroupValidateAndThrowAsync(
        _dataContext, employee, cancellationToken);
        await _dataContext.Employees.AddAsync(employee, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return employee.IsnEmployee;
    }
}


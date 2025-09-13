using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PoliceDepartament;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.Commands;

public sealed class DeleteEmployeeCommand : IRequest
{
    [Required]
    [FromQuery]
    public Guid IsnEmployee {  get; init; }
}
public sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly DataContext _dataContext;
    private readonly IEmployeeService _employeeService;

    public DeleteEmployeeCommandHandler(DataContext dataContext, IEmployeeService employeeService)
    {
        _dataContext = dataContext;
        _employeeService = employeeService;
    }
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dataContext.Employees.FirstOrDefaultAsync(x => x.IsnEmployee == request.IsnEmployee, cancellationToken)
        ?? throw new BusinessLogicException($"Работника с идентификатором \"{request.IsnEmployee}\" не существует");

        _dataContext.Employees.Remove(employee);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}

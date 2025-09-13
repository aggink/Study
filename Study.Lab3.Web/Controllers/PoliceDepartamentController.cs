using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.Commands;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.Queries;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.Commands;
using Study.Lab3.Web.Features.PoliceDepartament.Intern.Queries;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.Commands;
using Study.Lab3.Web.Features.PoliceDepartament.Officer.Queries;
using System.Threading.Tasks;

namespace Study.Lab3.Web.Controllers;

public class PoliceDepartamentController : Controller
{
    private readonly IMediator _mediator;
    public PoliceDepartamentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Employee
    [HttpPost(nameof(CreateEmployee), Name = nameof(CreateEmployee))]
    public async Task<ActionResult<Guid>> CreateEmployee(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(UpdateEmployee), Name = nameof(UpdateEmployee))]
    public async Task<ActionResult<Guid>> UpdateEmployee(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(DeleteEmployee), Name = nameof(DeleteEmployee))]
    public async Task<ActionResult<Guid>> DeleteEmployee(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet(nameof(GetListEmployees), Name = nameof(GetListEmployees))]
    public async Task<ActionResult<EmployeeDto[]>> GetListEmployees([FromQuery] GetListEmployeesQuery query,
    CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet(nameof(GetEmployeeByIsn), Name = nameof(GetEmployeeByIsn))]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeByIsn([FromQuery] GetEmployeeByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    #endregion

    #region Intern
    [HttpPost(nameof(CreateIntern), Name = nameof(CreateIntern))]
    public async Task<ActionResult<Guid>> CreateIntern(CreateInternCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(UpdateIntern), Name = nameof(UpdateIntern))]
    public async Task<ActionResult<Guid>> UpdateIntern(UpdateInternCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(DeleteIntern), Name = nameof(DeleteIntern))]
    public async Task<ActionResult<Guid>> DeleteIntern(DeleteInternCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet(nameof(GetListInterns), Name = nameof(GetListInterns))]
    public async Task<ActionResult<EmployeeDto[]>> GetListInterns([FromQuery] GetListInternsQuery query,
    CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet(nameof(GetInternByIsn), Name = nameof(GetInternByIsn))]
    public async Task<ActionResult<EmployeeDto>> GetInternByIsn([FromQuery] GetInternByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    #endregion

    #region Officer
    [HttpPost(nameof(CreateOfficer), Name = nameof(CreateOfficer))]
    public async Task<ActionResult<Guid>> CreateOfficer(CreateOfficerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(UpdateOfficer), Name = nameof(UpdateOfficer))]
    public async Task<ActionResult<Guid>> UpdateOfficer(UpdateOfficerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost(nameof(DeleteOfficer), Name = nameof(DeleteOfficer))]
    public async Task<ActionResult<Guid>> DeleteOfficer(DeleteOfficerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet(nameof(GetListOfficers), Name = nameof(GetListOfficers))]
    public async Task<ActionResult<EmployeeDto[]>> GetListOfficers([FromQuery] GetListOfficersQuery query,
    CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet(nameof(GetOfficerByIsn), Name = nameof(GetOfficerByIsn))]
    public async Task<ActionResult<EmployeeDto>> GetOfficerByIsn([FromQuery] GetOfficerByIsnQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    #endregion
}

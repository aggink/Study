using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PoliceDepartament.Employee.DtoModels;
using Study.Lab3.Web.Features.University.Groups.DtoModels;

namespace Study.Lab3.Web.Features.PoliceDepartament.Employee.Queries;

public sealed class GetListEmployeesQuery : IRequest<EmployeeDto[]>
{

}
public sealed class GetListEmployeesQueryHandler : IRequestHandler<GetListEmployeesQuery, EmployeeDto[]>
{
    private readonly DataContext _dataContext;
    public GetListEmployeesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<EmployeeDto[]> Handle(GetListEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Employees
        .AsNoTracking()
        .Select(x => new EmployeeDto
        {
            IsnEmployee = x.IsnEmployee,
            Name = x.Name,
            SurName = x.SurName,
            Work = x.Work
        })
        .ToArrayAsync(cancellationToken);
    }
}


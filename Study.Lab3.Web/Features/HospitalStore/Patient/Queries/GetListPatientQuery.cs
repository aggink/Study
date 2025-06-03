using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.Queries;

/// <summary>
/// Получение списка пациентов
/// </summary>
public sealed class GetListPatientQuery : IRequest<PatientDto[]>
{
}

public sealed class GetListPatientQueryHandler : IRequestHandler<GetListPatientQuery, PatientDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPatientQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PatientDto[]> Handle(GetListPatientQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Patients
            .AsNoTracking()
            .Select(x => new PatientDto
            {
                IsnPatient = x.IsnPatient,
                FullName = x.FullName,
                MedicalCardId = x.MedicalCardId,
                Phone = x.Phone
            })
            .OrderBy(x => x.FullName) // Сортировка по ФИО
            .ToArrayAsync(cancellationToken);
    }
}
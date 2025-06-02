using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.Queries;

/// <summary>
/// Получение пациента по идентификатору
/// </summary>
public sealed class GetPatientByIsnQuery : IRequest<PatientDto?>
{
    public Guid IsnPatient { get; }

    public GetPatientByIsnQuery(Guid isnPatient)
    {
        IsnPatient = isnPatient;
    }
}

public sealed class GetPatientByIsnQueryHandler : IRequestHandler<GetPatientByIsnQuery, PatientDto?>
{
    private readonly DataContext _dataContext;

    public GetPatientByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PatientDto?> Handle(GetPatientByIsnQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Patients
            .AsNoTracking()
            .Where(x => x.IsnPatient == request.IsnPatient)
            .Select(x => new PatientDto
            {
                IsnPatient = x.IsnPatient,
                FullName = x.FullName,
                MedicalCardId = x.MedicalCardId,
                Phone = x.Phone
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}
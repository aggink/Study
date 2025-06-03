using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Queries;

/// <summary>
/// Получение списка записей
/// </summary>
public sealed class GetListAppointmentsQuery : IRequest<AppointmentDto[]>
{
}

public sealed class GetListAppointmentsQueryHandler : IRequestHandler<GetListAppointmentsQuery, AppointmentDto[]>
{
    private readonly DataContext _dataContext;

    public GetListAppointmentsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AppointmentDto[]> Handle(GetListAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.BeautyAppointments
            .AsNoTracking()
            .Select(x => new AppointmentDto
            {
                IsnAppointment = x.IsnAppointment,
                IsnClient = x.IsnBeautyClient,
                IsnService = x.IsnBeautyService,
                Day = x.Day,
                Month = x.Month,
                Hour = x.Hour,
                Minutes = x.Minutes
            })
            .OrderBy(x => x.Month) // Сортировка по месяцу
            .ToArrayAsync(cancellationToken);
    }
}
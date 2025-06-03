using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Queries;

/// <summary>
/// Получение данных записи
/// </summary>
public class GetAppointmentByIsnQuery : IRequest<AppointmentDto>
{
    /// <summary>
    /// ID записи
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAppointment { get; init; }
}

public sealed class GetAppointmentByIsnQueryHandler : IRequestHandler<GetAppointmentByIsnQuery, AppointmentDto>
{
    private readonly DataContext _dataContext;

    public GetAppointmentByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AppointmentDto> Handle(GetAppointmentByIsnQuery request, CancellationToken cancellationToken)
    {
        var appointment = await _dataContext.BeautyAppointments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnAppointment == request.IsnAppointment, cancellationToken)
            ?? throw new BusinessLogicException($"Записи с идентификатором \"{request.IsnAppointment}\" не существует!");

        return new AppointmentDto
        {
            IsnAppointment = appointment.IsnAppointment,
            IsnClient = appointment.IsnBeautyClient,
            IsnService = appointment.IsnBeautyService,
            Day = appointment.Day,
            Month = appointment.Month,
            Hour = appointment.Hour,
            Minutes = appointment.Minutes
        };
    }
}
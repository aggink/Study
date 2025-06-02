using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Commands;

/// <summary>
/// Редактирование записи
/// </summary>
public sealed class UpdateAppointmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAppointmentDto Appointment { get; init; }
}

public sealed class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyAppointmentService _appointmentService;

    public UpdateAppointmentCommandHandler(DataContext dataContext, IBeautyAppointmentService appointmentService)
    {
        _dataContext = dataContext;
        _appointmentService = appointmentService;
    }

    public async Task<Guid> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _dataContext.BeautyAppointments.FirstOrDefaultAsync(x => x.IsnAppointment == request.Appointment.IsnAppointment, cancellationToken)
                ?? throw new BusinessLogicException($"Записи с идентификатором \"{request.Appointment.IsnAppointment}\" не существует!");

        appointment.Day = request.Appointment.Day;
        appointment.Month = request.Appointment.Month;
        appointment.Hour = request.Appointment.Hour;
        appointment.Minutes = request.Appointment.Minutes;

        await _appointmentService.CreateOrUpdateAppointmentValidate(_dataContext, appointment, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return appointment.IsnAppointment;
    }
}
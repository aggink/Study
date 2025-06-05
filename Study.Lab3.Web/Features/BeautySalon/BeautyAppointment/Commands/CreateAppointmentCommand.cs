using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Commands;

/// <summary>
/// Создание записи
/// </summary>
public sealed class CreateAppointmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные записи
    /// </summary>
    [Required]
    [FromBody]
    public CreateAppointmentDto Appointment { get; init; }
}

public sealed class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyAppointmentService _appointmentService;

    public CreateAppointmentCommandHandler(DataContext dataContext, IBeautyAppointmentService appointmentService)
    {
        _dataContext = dataContext;
        _appointmentService = appointmentService;
    }

    public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Storage.Models.BeautySalon.BeautyAppointment
        {
            IsnAppointment = Guid.NewGuid(),
            IsnBeautyClient = request.Appointment.IsnClient,
            IsnBeautyService = request.Appointment.IsnService,
            Day = request.Appointment.Day,
            Month = request.Appointment.Month,
            Hour = request.Appointment.Hour,
            Minutes = request.Appointment.Minutes,
        };

        await _appointmentService.CreateOrUpdateAppointmentValidateAndThrowAsync(_dataContext, appointment, cancellationToken);

        await _dataContext.BeautyAppointment.AddAsync(appointment, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return appointment.IsnAppointment;
    }
}
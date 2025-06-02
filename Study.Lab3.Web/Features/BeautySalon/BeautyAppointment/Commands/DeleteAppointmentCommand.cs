using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyAppointment.Commands;

/// <summary>
/// Удаление записи
/// </summary>
public sealed class DeleteAppointmentCommand : IRequest
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAppointment { get; init; }
}

public sealed class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyAppointmentService _appointmentService;

    public DeleteAppointmentCommandHandler(DataContext dataContext, IBeautyAppointmentService appointmentService)
    {
        _dataContext = dataContext;
        _appointmentService = appointmentService;
    }

    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _dataContext.BeautyAppointments.FirstOrDefaultAsync(x => x.IsnAppointment == request.IsnAppointment, cancellationToken)
                ?? throw new BusinessLogicException($"Записи с идентификатором \"{request.IsnAppointment}\" не существует!");

        _dataContext.BeautyAppointments.Remove(appointment);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}
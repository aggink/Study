using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Web.Features.Pharmacy.Customers.Commands;
using Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;
using Study.Lab3.Web.Features.Pharmacy.Customers.Queries;
using Study.Lab3.Web.Features.Pharmacy.Medications.Commands;
using Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;
using Study.Lab3.Web.Features.Pharmacy.Medications.Queries;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.Commands;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.Queries;

namespace Study.Lab3.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PharmacyController : Controller
{
    private readonly IMediator _mediator;

    public PharmacyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region PharmacyCustomer

    /// <summary>
    /// Создание клиента аптеки
    /// </summary>
    /// <param name="command">Данные клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданного клиента</returns>
    [HttpPost(nameof(CreatePharmacyCustomer), Name = nameof(CreatePharmacyCustomer))]
    public async Task<ActionResult<Guid>> CreatePharmacyCustomer(CreatePharmacyCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных клиента аптеки
    /// </summary>
    /// <param name="command">Данные клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленного клиента</returns>
    [HttpPost(nameof(UpdatePharmacyCustomer), Name = nameof(UpdatePharmacyCustomer))]
    public async Task<ActionResult<Guid>> UpdatePharmacyCustomer(UpdatePharmacyCustomerCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление клиента аптеки
    /// </summary>
    /// <param name="command">Идентификатор клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePharmacyCustomer), Name = nameof(DeletePharmacyCustomer))]
    public async Task<ActionResult> DeletePharmacyCustomer(DeletePharmacyCustomerCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка клиентов аптеки
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список клиентов аптеки</returns>
    [HttpGet(nameof(GetListPharmacyCustomers), Name = nameof(GetListPharmacyCustomers))]
    public async Task<ActionResult<PharmacyCustomerDto[]>> GetListPharmacyCustomers([FromQuery] GetPharmacyCustomersListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение клиента аптеки по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором клиента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные клиента аптеки</returns>
    [HttpGet(nameof(GetPharmacyCustomerById), Name = nameof(GetPharmacyCustomerById))]
    public async Task<ActionResult<PharmacyCustomerDto>> GetPharmacyCustomerById([FromQuery] GetPharmacyCustomerByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Medication

    /// <summary>
    /// Создание лекарства
    /// </summary>
    /// <param name="command">Данные лекарства</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданного лекарства</returns>
    [HttpPost(nameof(CreateMedication), Name = nameof(CreateMedication))]
    public async Task<ActionResult<Guid>> CreateMedication(CreatePharmacyMedicationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных лекарства
    /// </summary>
    /// <param name="command">Данные лекарства</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленного лекарства</returns>
    [HttpPost(nameof(UpdateMedication), Name = nameof(UpdateMedication))]
    public async Task<ActionResult<Guid>> UpdateMedication(UpdatePharmacyMedicationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление лекарства
    /// </summary>
    /// <param name="command">Идентификатор лекарства</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeleteMedication), Name = nameof(DeleteMedication))]
    public async Task<ActionResult> DeleteMedication(DeletePharmacyMedicationCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка лекарств
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список лекарств</returns>
    [HttpGet(nameof(GetListMedications), Name = nameof(GetListMedications))]
    public async Task<ActionResult<PharmacyMedicationDto[]>> GetListMedications([FromQuery] GetPharmacyMedicationsListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение лекарства по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором лекарства</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные лекарства</returns>
    [HttpGet(nameof(GetMedicationById), Name = nameof(GetMedicationById))]
    public async Task<ActionResult<PharmacyMedicationDto>> GetMedicationById([FromQuery] GetPharmacyMedicationByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion

    #region Prescription

    /// <summary>
    /// Создание рецепта
    /// </summary>
    /// <param name="command">Данные рецепта</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданного рецепта</returns>
    [HttpPost(nameof(CreatePrescription), Name = nameof(CreatePrescription))]
    public async Task<ActionResult<Guid>> CreatePrescription(CreatePrescriptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление данных рецепта
    /// </summary>
    /// <param name="command">Данные рецепта</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленного рецепта</returns>
    [HttpPost(nameof(UpdatePrescription), Name = nameof(UpdatePrescription))]
    public async Task<ActionResult<Guid>> UpdatePrescription(UpdatePrescriptionCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удаление рецепта
    /// </summary>
    /// <param name="command">Идентификатор рецепта</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost(nameof(DeletePrescription), Name = nameof(DeletePrescription))]
    public async Task<ActionResult> DeletePrescription(DeletePrescriptionCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Получение списка рецептов
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список рецептов</returns>
    [HttpGet(nameof(GetListPrescriptions), Name = nameof(GetListPrescriptions))]
    public async Task<ActionResult<PrescriptionDto[]>> GetListPrescriptions([FromQuery] GetPrescriptionsListQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получение рецепта по идентификатору
    /// </summary>
    /// <param name="query">Запрос с идентификатором рецепта</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные рецепта</returns>
    [HttpGet(nameof(GetPrescriptionById), Name = nameof(GetPrescriptionById))]
    public async Task<ActionResult<PrescriptionDto>> GetPrescriptionById([FromQuery] GetPrescriptionByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    #endregion
}
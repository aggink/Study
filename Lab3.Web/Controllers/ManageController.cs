using Lab3.Web.Features.University.Groups.Commands;
using Lab3.Web.Features.University.Groups.DtoModels;
using Lab3.Web.Features.University.Groups.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ManageController : Controller
    {
        private readonly IMediator _mediator;

        public ManageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Создание группы
        /// </summary>
        /// <param name="command">Dto запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор группы</returns>
        [HttpPost(nameof(CreateGroup), Name = nameof(CreateGroup))]
        public async Task<ActionResult<Guid>> CreateGroup(CreateGroupCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Редактирование данных группы
        /// </summary>
        /// <param name="command">Dto запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор группы</returns>
        [HttpPost(nameof(UpdateGroup), Name = nameof(UpdateGroup))]
        public async Task<ActionResult<Guid>> UpdateGroup(UpdateGroupCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="command">Dto запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        [HttpPost(nameof(DeleteGroup), Name = nameof(DeleteGroup))]
        public async Task<ActionResult<Guid>> DeleteGroup(DeleteGroupCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Получение списка групп
        /// </summary>
        /// <param name="query">Dto запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список групп</returns>
        [HttpGet(nameof(GetListGroups), Name = nameof(GetListGroups))]
        public async Task<ActionResult<GroupDto[]>> GetListGroups(GetListGroupsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}

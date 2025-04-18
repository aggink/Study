using CoreLib.Common.Extensions;
using Lab3.Logic.Interfaces.Services.University;
using Lab3.Storage.Database;
using Lab3.Web.Features.University.Groups.DtoModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Web.Features.University.Groups.Commands
{
    /// <summary>
    /// Редактирование группы
    /// </summary>
    public sealed class UpdateGroupCommand : IRequest<Guid>
    {
        /// <summary>
        /// Данные группы
        /// </summary>
        [Required]
        [FromBody]
        public UpdateGroupDto Group { get; init; }
    }

    public sealed class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Guid>
    {
        private readonly DataContext _dataContext;
        private readonly IGroupService _groupService;

        public UpdateGroupCommandHandler(
            DataContext dataContext,
            IGroupService groupService)
        {
            _dataContext = dataContext;
            _groupService = groupService;
        }

        public async Task<Guid> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.Group.IsnGroup, cancellationToken)
                ?? throw new BusinessLogicException($"Группа с идентификатором \"{request.Group.IsnGroup}\" не найдена");

            group.Name = request.Group.Name;

            await _groupService.CreateOrUpdateGroupValidateAsync(_dataContext, group, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);
            return group.IsnGroup;
        }
    }
}

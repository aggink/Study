using Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Web.Features.University.Groups.DtoModels
{
    public sealed record CreateGroupDto
    {
        /// <summary>
        /// Наименование группы
        /// </summary>
        [Required, MaxLength(ModelLengthConstants.Group.Name)]
        public string Name { get; init; }
    }
}

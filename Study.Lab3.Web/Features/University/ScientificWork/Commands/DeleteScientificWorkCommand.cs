using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;
public record DeleteScientificWorkCommand : IRequest<Unit>
    {
        public Guid IsnScientificWork { get; init; }
    }

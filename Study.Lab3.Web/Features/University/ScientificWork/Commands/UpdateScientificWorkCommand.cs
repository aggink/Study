using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
using System.ComponentModel.DataAnnotations.Schema;


namespace Study.Lab3.Web.Features.University.ScientificWork.Commands;
public record UpdateScientificWorkCommand : IRequest<Guid>
    {
        public Guid IsnScientificWork { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int PageCount { get; init; }
        public bool IsPublished { get; init; }
    }
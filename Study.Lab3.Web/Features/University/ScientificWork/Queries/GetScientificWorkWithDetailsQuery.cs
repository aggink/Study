using MediatR;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;

namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetScientificWorkWithDetailsQuery : IRequest<ScientificWorkWithDetailsDto>
    {
        public Guid IsnScientificWork { get; init; }
    }
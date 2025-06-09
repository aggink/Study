using MediatR;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;


namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetListScientificWorksQuery : IRequest<ScientificWorkDto[]>
    {
        public Guid? IsnStudent { get; init; }
        public Guid? IsnSubject { get; init; }
        public bool? IsPublished { get; init; }
    }
using MediatR;
using Study.Lab3.Web.Features.University.ScientificWork.DtoModels;

namespace Study.Lab3.Web.Features.University.ScientificWork.Queries;
    public record GetPagedScientificWorksQuery : IRequest<PagedResult<ScientificWorkDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
        public string SortBy { get; init; } = "PublicationDate";
        public bool SortDescending { get; init; } = true;
    }
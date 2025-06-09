using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
    public record ScientificWorkDto
    {
        public Guid IsnScientificWork { get; init; }
        public Guid IsnStudent { get; init; }
        public Guid IsnSubject { get; init; }
        public string Title { get; init; }
        public int PageCount { get; init; }
        public DateTime PublicationDate { get; init; }
        public bool IsPublished { get; init; }
    }
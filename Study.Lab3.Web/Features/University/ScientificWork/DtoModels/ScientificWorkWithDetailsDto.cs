using Study.Lab3.Storage.Constants;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ScientificWork.DtoModels;
    public record ScientificWorkWithDetailsDto
    {
        public Guid IsnScientificWork { get; init; }
        public StudentDto1 Student { get; init; }
        public SubjectDto1 Subject { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int PageCount { get; init; }
        public DateTime PublicationDate { get; init; }
        public WorkReferenceDto[] References { get; init; }
    }

    public record StudentDto1
    {
        public Guid IsnStudent { get; init; }
        public string FullName { get; init; }
    }

    public record SubjectDto1
    {
        public Guid IsnSubject { get; init; }
        public string Name { get; init; }
    }

    public record WorkReferenceDto
    {
        public Guid IsnReference { get; init; }
        public Guid ReferencedWorkId { get; init; }
    }
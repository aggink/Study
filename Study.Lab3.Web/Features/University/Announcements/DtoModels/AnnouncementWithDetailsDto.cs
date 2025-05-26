/*namespace Study.Lab3.Web.Features.University.Announcements.DtoModels;

public sealed record AnnouncementWithDetailsDto
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    public Guid IsnAnnouncement { get; init; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// ФИО преподавателя
    /// </summary>
    public string TeacherFullName { get; init; }

    /// <summary>
    /// Заголовок объявления
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Текст объявления
    /// </summary>
    public string Content { get; init; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishDate { get; init; }

    /// <summary>
    /// Важность объявления
    /// </summary>
    public bool IsImportant { get; init; }

    /// <summary>
    /// Группы, для которых предназначено объявление
    /// </summary>
    public AnnouncementGroupItemDto[] Groups { get; init; }
}

public sealed record AnnouncementGroupItemDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public Guid IsnGroup { get; init; }

    /// <summary>
    /// Название группы
    /// </summary>
    public string GroupName { get; init; }
}*/
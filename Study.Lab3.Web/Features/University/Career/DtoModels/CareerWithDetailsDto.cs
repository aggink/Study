<<<<<<< HEAD
﻿namespace Study.Lab3.Web.Features.University.TheCareer.DtoModels;
=======
﻿namespace Study.Lab3.Web.Features.University.Career.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record CareerWithDetailsDto
{
    /// <summary>
    /// Идентификатор карьеры
    /// </summary>
    public Guid IsnCareer { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ФИО студента
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Идентификатор собеседования
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название собеседования
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения собеседоваиния
    /// </summary>
    public DateTime CareerDate { get; init; }
}
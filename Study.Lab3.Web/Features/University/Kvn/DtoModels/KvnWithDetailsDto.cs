<<<<<<< HEAD
﻿namespace Study.Lab3.Web.Features.University.TheKvn.DtoModels;
=======
﻿namespace Study.Lab3.Web.Features.University.Kvn.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record KvnWithDetailsDto
{
    /// <summary>
    /// Идентификатор квн
    /// </summary>
    public Guid IsnKvn { get; init; }

    /// <summary>
    /// Идентификатор участника
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// ФИО участника
    /// </summary>
    public string StudentFullName { get; init; }

    /// <summary>
    /// Идентификатор темы выступления
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Название темы выступления
    /// </summary>
    public string SubjectName { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения выступления
    /// </summary>
    public DateTime KvnDate { get; init; }
}
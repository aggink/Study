<<<<<<< HEAD
﻿namespace Study.Lab3.Web.Features.University.TheSportclub.DtoModels;
=======
﻿namespace Study.Lab3.Web.Features.University.Sportclub.DtoModels;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

public sealed record SportclubDto
{
    /// <summary>
    /// Идентификатор спортивного клуба
    /// </summary>
    public Guid IsnSportclub { get; init; }

    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid IsnStudent { get; init; }

    /// <summary>
    /// Идентификатор соревнований
    /// </summary>
    public Guid IsnSubject { get; init; }

    /// <summary>
    /// Значение количества участников
    /// </summary>
    public int ParticipantsCount { get; init; }

    /// <summary>
    /// Дата проведения соревнований
    /// </summary>
    public DateTime SportclubDate { get; init; }
}
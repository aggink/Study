﻿using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Students.DtoModels;

public sealed record CreateStudentDto
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    public Guid IsnGroup { get; init; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.SurName)]
    public string SurName { get; init; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.Name)]
    public string Name { get; init; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.PatronymicName)]
    public string PatronymicName { get; init; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; init; }

    /// <summary>
    /// Возраст
    /// </summary>
    [Range(ModelConstants.Student.AgeMin, ModelConstants.Student.AgeMax)]
    public int Age { get; init; }
}

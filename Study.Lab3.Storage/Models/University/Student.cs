﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Enums.University;

namespace Study.Lab3.Storage.Models.University;

/// <summary>
/// Студент
/// </summary>
[Index(nameof(IsnGroup))]
public class Student
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnStudent { get; set; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [ForeignKey(nameof(Group))]
    public Guid IsnGroup { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.SurName)]
    public string SurName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.Name)]
    public string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    [Required, MaxLength(ModelConstants.Student.PatronymicName)]
    public string PatronymicName { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public SexType Sex { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    [Range(ModelConstants.Student.AgeMin, ModelConstants.Student.AgeMax)]
    public int Age { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public virtual Group Group { get; set; }

    /// <summary>
    /// Связь с таблицей студента - оценки
    /// </summary>
    [InverseProperty(nameof(Grade.Student))]
    public virtual ICollection<Grade> Grades { get; set; }

    /// <summary>
    /// Список регистраций студента на экзамены
    /// </summary>
    [InverseProperty(nameof(ExamRegistration.Student))]
    public virtual ICollection<ExamRegistration> ExamRegistrations { get; set; }

    /// <summary>
    /// Связь с таблицей студента - спортивный клуб
    /// </summary>
    [InverseProperty(nameof(Sportclub.Student))]
    public virtual ICollection<Sportclub> Sportclubs { get; set; }

    /// <summary>
    /// Связь с квн
    /// </summary>
    [InverseProperty(nameof(Kvn.Student))]
    public virtual ICollection<Kvn> Kvns { get; set; }

    /// <summary>
    /// Связь с таблицей студента - карьера
    /// </summary>
    [InverseProperty(nameof(Career.Student))]
    public virtual ICollection<Career> Careers { get; set; }

    /// <summary>
    /// Связь с проектной деятельностью
    /// </summary>
    [InverseProperty(nameof(ProjectActivities.Student))]
    public virtual ICollection<ProjectActivities> ProjectActivitiess { get; set; }

    [InverseProperty(nameof(StudentLab.Student))]
    public virtual ICollection<StudentLab> StudentLabs { get; set; }

    /// <summary>
    /// Связь с заметками студента
    /// </summary>
    [InverseProperty(nameof(StudentNote.Student))]
    public virtual ICollection<StudentNote> Notes { get; set; }

    /// Связь с посещениями
    /// </summary>
    [InverseProperty(nameof(AttendanceLog.Student))]
    public virtual ICollection<AttendanceLog> AttendanceLogs { get; set; }

    /// <summary>
    /// Оценки
    /// </summary>
    [InverseProperty(nameof(Profcom.Student))]
    public virtual ICollection<Profcom> Profcoms { get; set; }

    /// <summary>
    /// Связь с таблицей студента - спортивный клуб
    /// </summary>
    [InverseProperty(nameof(Pingpongclub.Student))]
    public virtual ICollection<Pingpongclub> Pingpongclubs { get; set; }
}
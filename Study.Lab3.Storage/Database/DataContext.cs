using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Storage.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        //
    }

    /// <summary>
    /// Студенты
    /// </summary>
    public virtual DbSet<Student> Students { get; set; }

    /// <summary>
    /// Группы
    /// </summary>
    public virtual DbSet<Group> Groups { get; set; }

    /// <summary>
    /// Предметы
    /// </summary>
    public virtual DbSet<Subject> Subjects { get; set; }

    /// <summary>
    /// Связь предметов и групп
    /// </summary>
    public virtual DbSet<SubjectGroup> SubjectsGroups { get; set; }

    /// <summary>
    /// Учителя
    /// </summary>
    public virtual DbSet<Teacher> Teachers { get; set; }

    /// <summary>
    /// Связь учителей и предметов
    /// </summary>
    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    /// <summary>
    /// Оценки
    /// </summary>
    public virtual DbSet<Grade> Grades { get; set; }
}

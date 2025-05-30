using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Storage.Models.Library;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Storage.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    #region University

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

    /// <summary>
    /// Задания
    /// </summary>
    public virtual DbSet<Assignment> Assignments { get; set; }

    /// <summary>
    /// Учебные материалы
    /// </summary>
    public virtual DbSet<Material> Materials { get; set; }

    /// <summary>
    /// Объявления
    /// </summary>
    public virtual DbSet<Announcement> Announcements { get; set; }

    /// <summary>
    /// Связь объявлений с группами
    /// </summary>
    public virtual DbSet<AnnouncementGroup> AnnouncementGroups { get; set; }

    /// <summary>
    /// Экзамены
    /// </summary>
    public virtual DbSet<Exam> Exams { get; set; }

    /// <summary>
    /// Регистрации на экзамены
    /// </summary>
    public virtual DbSet<ExamRegistration> ExamRegistrations { get; set; }

    /// <summary>
    /// Результаты экзаменов
    /// </summary>
    public virtual DbSet<ExamResult> ExamResults { get; set; }

    /// <summary>
    /// Авторы
    /// </summary>
    public virtual DbSet<Authors> Authors { get; set; }

    /// <summary>
    /// Книги
    /// </summary>
    public virtual DbSet<Books> Books { get; set; }

    /// <summary>
    /// Связь авторов и книг
    /// </summary>
    public virtual DbSet<AuthorBooks> AuthorBooks { get; set; }
    
    #endregion
    
    #region Cinema

    /// <summary>
    /// Фильмы
    /// </summary>
    public virtual DbSet<Movie> Movies { get; set; }

    /// <summary>
    /// Жанры фильмов
    /// </summary>
    public virtual DbSet<Genre> Genres { get; set; }

    /// <summary>
    /// Связь фильмов и жанров
    /// </summary>
    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    /// <summary>
    /// Кинозалы
    /// </summary>
    public virtual DbSet<Hall> Halls { get; set; }

    /// <summary>
    /// Места в залах
    /// </summary>
    public virtual DbSet<Seat> Seats { get; set; }

    /// <summary>
    /// Киносеансы
    /// </summary>
    public virtual DbSet<Session> Sessions { get; set; }

    /// <summary>
    /// Клиенты
    /// </summary>
    public virtual DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// Билеты
    /// </summary>
    public virtual DbSet<Ticket> Tickets { get; set; }

    #endregion

    #region HospitalStore

    /// <summary>
    /// Заказы
    /// </summary>
    public virtual DbSet<Order> Orders { get; set; }

    /// <summary>
    /// Покупатели
    /// </summary>
    public virtual DbSet<Patient> Patients { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public virtual DbSet<Product> Products { get; set; }

    #endregion
}
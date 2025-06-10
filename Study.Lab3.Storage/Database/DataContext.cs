using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Models.BeautySalon;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Storage.Models.Fitness;
using Study.Lab3.Storage.Models.HospitalStore;
using Study.Lab3.Storage.Models.Library;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Storage.Models.University;
using Customer = Study.Lab3.Storage.Models.Cinema.Customer;
using ShelterCustomer = Study.Lab3.Storage.Models.Shelter.Customer;

namespace Study.Lab3.Storage.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            // Только для обязательных (not nullable) внешних ключей
            if (!foreignKey.IsRequired)
                continue;

            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
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

    /// <summary>
    /// Профком
    /// </summary>
    public virtual DbSet<Profcom> TheProfcom { get; set; }

    /// <summary>
    /// Спортивный клуб
    /// </summary>
    public virtual DbSet<Sportclub> Sportclub { get; set; }

    /// <summary>
    /// Квн
    /// </summary>
    public virtual DbSet<Kvn> TheKvn { get; set; }

    /// <summary>
    /// Карьера
    /// </summary>
    public virtual DbSet<Career> Career { get; set; }

    /// <summary>
    /// Заметки
    /// </summary>
    public virtual DbSet<StudentNote> StudentNotes { get; set; }
    /// Учителя
    /// </summary>
    public virtual DbSet<ProjectActivities> TheProjectActivities { get; set; }

    /// <summary>
    /// Лабы
    /// </summary>
    public virtual DbSet<Labs> Labs { get; set; }
    /// <summary>
    /// Оценки студентов по лабам Лабы
    /// </summary>
    public virtual DbSet<StudentLab> StudentLab { get; set; }

    /// <summary>
    /// Посещение
    /// </summary>
    public virtual DbSet<AttendanceLog> TheAttendanceLog { get; set; }

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

    #region Restaurants

    /// <summary>
    /// Рестораны
    /// </summary>
    public virtual DbSet<Restaurant> Restaurants { get; set; }

    /// <summary>
    /// Меню ресторанов
    /// </summary>
    public virtual DbSet<Menu> Menus { get; set; }

    /// <summary>
    /// Позиции меню
    /// </summary>
    public virtual DbSet<MenuItem> MenuItems { get; set; }

    /// <summary>
    /// Заказы
    /// </summary>
    public virtual DbSet<RestaurantOrder> RestaurantOrders { get; set; }

    /// <summary>
    /// Позиции заказов
    /// </summary>
    public virtual DbSet<OrderItem> OrderItems { get; set; }

    #endregion

    #region BeautySalon

    /// <summary>
    /// Клиенты
    /// </summary>
    public virtual DbSet<BeautyClient> BeautyClient { get; set; }

    /// <summary>
    /// Услуги
    /// </summary>
    public virtual DbSet<BeautyService> BeautyService { get; set; }

    /// <summary>
    /// Записи на услуги
    /// </summary>
    public virtual DbSet<BeautyAppointment> BeautyAppointment { get; set; }

    #endregion
    
    #region Shelter

    /// <summary>
    /// Клиенты
    /// </summary>
    public virtual DbSet<ShelterCustomer> ShelterCustomers { get; set; }

    /// <summary>
    /// Коты с приюта
    /// </summary>
    public virtual DbSet<Cat> Cats { get; set; }

    /// <summary>
    /// Заказ на усыновление кота
    /// </summary>
    public virtual DbSet<Adoption> Adoptions { get; set; }

    #endregion

    #region SweetFactory

    /// <summary>
    /// Конфеты
    /// </summary>
    public virtual DbSet<Sweet> Sweets { get; set; }

    /// <summary>
    /// Конфетная фабрика
    /// </summary>
    public virtual DbSet<SweetFactory> SweetFactories { get; set; }

    /// <summary>
    /// Тип конфет
    /// </summary>
    public virtual DbSet<SweetType> SweetTypes { get; set; }

    /// <summary>
    /// Sweet Production
    /// </summary>
    public virtual DbSet<SweetProduction> SweetProductions { get; set; }

    #endregion
    
    #region Workshop

    /// <summary>
    /// Мастера
    /// </summary>
    public virtual DbSet<Models.Workshop.Master> Masters { get; set; }

    /// <summary>
    /// Услуги
    /// </summary>
    public virtual DbSet<Models.Workshop.Service> Services { get; set; }

    /// <summary>
    /// Заказы на услуги
    /// </summary>
    public virtual DbSet<Models.Workshop.ServiceOrder> ServiceOrders { get; set; }

    #endregion
    
    #region Fitness

    /// <summary>
    /// Участники фитнес-центра
    /// </summary>
    public virtual DbSet<FitnessMember> Members { get; set; }

    /// <summary>
    /// Тренеры фитнес-центра
    /// </summary>
    public virtual DbSet<FitnessTrainer> Trainers { get; set; }

    /// <summary>
    /// Оборудование фитнес-центра
    /// </summary>
    public virtual DbSet<FitnessEquipment> Equipments { get; set; }

    #endregion

}
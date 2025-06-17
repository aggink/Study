using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Models.BeautySalon;
using Study.Lab3.Storage.Models.CarService;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Storage.Models.Fitness;
using Study.Lab3.Storage.Models.GameStore;
using Study.Lab3.Storage.Models.HospitalStore;
using Study.Lab3.Storage.Models.Library;
using Study.Lab3.Storage.Models.Messenger;
using Study.Lab3.Storage.Models.Restaurants;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Storage.Models.Sweets;
using Study.Lab3.Storage.Models.TravelAgency;
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
    public virtual DbSet<Profcom> Profcoms { get; set; }

    /// <summary>
    /// Спортивный клуб
    /// </summary>
    public virtual DbSet<Sportclub> Sportclub { get; set; }

    /// <summary>
    /// Квн
    /// </summary>
    public virtual DbSet<Kvn> Kvns { get; set; }

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
    public virtual DbSet<ProjectActivities> ProjectActivities { get; set; }

    /// <summary>
    /// Лабы
    /// </summary>
    public virtual DbSet<Labs> Labs { get; set; }

    /// <summary>
    /// Оценки студентов по лабам
    /// </summary>
    public virtual DbSet<StudentLab> StudentLab { get; set; }

    /// <summary>
    /// Посещение
    /// </summary>
    public virtual DbSet<AttendanceLog> TheAttendanceLog { get; set; }

    /// <summary>
    /// Спортивный клуб
    /// </summary>
    public virtual DbSet<Pingpongclub> Pingpongclub { get; set; }

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
    /// Мини пиги с приюта
    /// </summary>
    public virtual DbSet<MiniPig> MiniPigs { get; set; }

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
    public virtual DbSet<FitnessEquipment> FitnessEquipments { get; set; }

    #endregion

    #region CarService

    /// <summary>
    /// Машина
    /// </summary>
    public virtual DbSet<Car> Cars { get; set; }
    
    /// <summary>
    /// Владелец
    /// </summary>
    public virtual DbSet<Owner> Owners { get; set; }
    
    /// <summary>
    /// Запись Обслуживания
    /// </summary>
    public virtual DbSet<ServiceRecord> ServiceRecords { get; set; }

    #endregion

    #region TravelAgency

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<TravelCustomer> TravelCustomers { get; set; }

    #endregion

    #region GameStore

    /// <summary>
    /// Игры
    /// </summary>
    public virtual DbSet<Game> Games { get; set; }

    /// <summary>
    /// Разработчики игр
    /// </summary>
    public virtual DbSet<Developer> Developers { get; set; }

    /// <summary>
    /// Игровые платформы
    /// </summary>
    public virtual DbSet<Platform> Platforms { get; set; }

    #endregion

    #region Messenger

    /// <summary>
    /// Пользователи
    /// </summary>
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public virtual DbSet<Post> Posts { get; set; }

    /// <summary>
    /// Изображения
    /// </summary>
    public virtual DbSet<Image> Images { get; set; }

    /// <summary>
    /// Вложения
    /// </summary>
    public virtual DbSet<ImageEmbed> ImageEmbeds { get; set; }

    #endregion
}

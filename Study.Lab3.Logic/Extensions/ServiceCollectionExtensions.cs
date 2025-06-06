﻿using Microsoft.Extensions.DependencyInjection;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Logic.Interfaces.Services.Library;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Logic.Services.BeautySalon;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Logic.Services.Cinema;
using Study.Lab3.Logic.Services.HospitalStore;
using Study.Lab3.Logic.Services.Library;
using Study.Lab3.Logic.Services.Restaurants;
using Study.Lab3.Logic.Services.University;
using Study.Lab3.Logic.Services.Workshop;


namespace Study.Lab3.Logic.Extensions;

/// <summary>
/// Расширения для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация сервисов библиотеки Logic
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public static void AddLogicServiceCollection(this IServiceCollection services)
    {
        services.AddSingleton<IGroupService, GroupService>();
        services.AddSingleton<ISubjectService, SubjectService>();
        services.AddSingleton<ITeacherService, TeacherService>();
        services.AddSingleton<ITeacherSubjectService, TeacherSubjectService>();
        services.AddSingleton<IGradeService, GradeService>();
        services.AddSingleton<IAssignmentService, AssignmentService>();
        services.AddSingleton<IMaterialService, MaterialService>();
        services.AddSingleton<IAnnouncementService, AnnouncementService>();
        services.AddSingleton<IExamService, ExamService>();
        services.AddSingleton<IExamRegistrationService, ExamRegistrationService>();
        services.AddSingleton<IExamResultService, ExamResultService>();
        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<IAuthorService, AuthorService>();
        services.AddSingleton<IAuthorBookService, AuthorBookService>();
        services.AddSingleton<IMovieService, MovieService>();
        services.AddSingleton<IGenreService, GenreService>();
        services.AddSingleton<IHallService, HallService>();
        services.AddSingleton<ISessionService, SessionService>();
        services.AddSingleton<ICustomerService, CustomerService>();
        services.AddSingleton<ITicketService, TicketService>();
        services.AddSingleton<IProfcomService, ProfcomService>();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<ISportclubService, SportclubService>();
        services.AddSingleton<IPatientService, PatientService>();
        services.AddSingleton<IProductService, ProductService>();
        services.AddSingleton<IRestaurantService, RestaurantService>();
        services.AddSingleton<IMenuService, MenuService>();
        services.AddSingleton<IMenuItemService, MenuItemService>();
        services.AddSingleton<IRestaurantOrderService, RestaurantOrderService>();
        services.AddSingleton<IOrderItemService, OrderItemService>();
        services.AddSingleton<IKvnService, KvnService>();
        services.AddSingleton<IBeautyClientService, BeautyClientService>();
        services.AddSingleton<IBeautyServiceService, BeautyServiceService>();
        services.AddSingleton<IBeautyAppointmentService, BeautyAppointmentService>();
        services.AddSingleton<ICareerService, CareerService>();
        services.AddSingleton<IMasterService, MasterService>();
        services.AddSingleton<IServiceService, ServiceService>();
        services.AddSingleton<IServiceOrderService, ServiceOrderService>();
    }
}
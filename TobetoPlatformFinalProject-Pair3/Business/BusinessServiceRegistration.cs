using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Entities.Abstracts;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Jwt;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAbilityService, AbilityManager>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementsNewsCategoryService, AnnouncementsNewsCategoryManager>();
        services.AddScoped<IApplicationService, ApplicationManager>();
        services.AddScoped<IAsyncContentService, AsyncContentManager>();
        services.AddScoped<IAsyncCourseService, AsyncCourseManager>();
        services.AddScoped<IAsyncLessonsDetailService, AsyncLessonsDetailManager>();
        services.AddScoped<IAsyncLessonsOfContentService, AsyncLessonsOfContentManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<IContactUsService, ContactUsManager>();
        services.AddScoped<ICourseService, CourseManager>();
        services.AddScoped<ICourseCategoryService, CourseCategoryManager>();
        services.AddScoped<ICourseDetailService, CourseDetailManager>();
        services.AddScoped<ICourseExamService, CourseExamManager>();
        services.AddScoped<IEducationService, EducationManager>();
        services.AddScoped<IExperienceService, ExperienceManager>();
        services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<ILiveContentService, LiveContentManager>();
        services.AddScoped<ILiveCourseService, LiveCourseManager>();
        services.AddScoped<INewsService, NewsManager>();
        services.AddScoped<IPasswordResetService, PasswordResetManager>();
        services.AddScoped<IPersonalInfoService, PersonalInfoManager>();
        services.AddScoped<IProjectService, ProjectManager>();
        services.AddScoped<ISessionService, SessionManager>();
        services.AddScoped<ISettingsService, SettingsManager>();
        services.AddScoped<ISocialAccountService, SocialAccountManager>();
        services.AddScoped<IStudentService, StudentManager>();
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}
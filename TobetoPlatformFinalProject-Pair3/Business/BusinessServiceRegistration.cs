using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Entities.Abstracts;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Jwt;
using Business.BusinessRules;
using Core.Utilities.Business.Rules;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

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
    public static IServiceCollection AddSubClassesOfType(
this IServiceCollection services,
Assembly assembly,
Type type,
Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}

using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TobetoPlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformDb")));
        services.AddScoped<IAbilityDal, EfAbilityDal>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        services.AddScoped<IAnnouncementsNewsCategoryDal, EfAnnouncementsNewsCategoryDal>();
        services.AddScoped<IApplicationDal, EfApplicationDal>();
        services.AddScoped<IAsyncContentDal, EfAsyncContentDal>();
        services.AddScoped<IAsyncCourseDal, EfAsyncCourseDal>();
        services.AddScoped<IAsyncLessonsOfContentDal, EfAsyncLessonsOfContentDal>();
        services.AddScoped<IAsyncLessonsDetailDal, EfAsyncLessonsDetailDal>();
        services.AddScoped<ICertificateDal, EfCertificateDal>();
        services.AddScoped<IContactUsDal, EfContactUsDal>();
        services.AddScoped<ICourseDal, EfCourseDal>();
        services.AddScoped<ICourseCategoryDal, EfCourseCategoryDal>();
        services.AddScoped<ICourseDetailDal, EfCourseDetailDal>();
        services.AddScoped<ICourseExamDal, EfCourseExamDal>();
        services.AddScoped<IEducationDal, EfEducationDal>();
        services.AddScoped<IExperienceDal, EfExperienceDal>();
        services.AddScoped<IForeignLanguageDal, EfForeignLanguageDal>();
        services.AddScoped<IInstructorDal, EfInstructorDal>();
        services.AddScoped<ILiveContentDal, EfLiveContentDal>();
        services.AddScoped<ILiveCourseDal, EfLiveCourseDal>();
        services.AddScoped<INewsDal, EfNewsDal>();
        services.AddScoped<IPasswordResetDal, EfPasswordResetDal>();
        services.AddScoped<IPersonalInfoDal, EfPersonalInfoDal>();
        services.AddScoped<IProjectDal, EfProjectDal>();
        services.AddScoped<ISessionDal, EfSessionDal>();
        services.AddScoped<ISettingsDal, EfSettingsDal>();
        services.AddScoped<ISocialAccountDal, EfSocialAccountDal>();
        services.AddScoped<IStudentDal, EfStudentDal>();
        services.AddScoped<ISurveyDal, EfSurveyDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();

        return services;
    }
}

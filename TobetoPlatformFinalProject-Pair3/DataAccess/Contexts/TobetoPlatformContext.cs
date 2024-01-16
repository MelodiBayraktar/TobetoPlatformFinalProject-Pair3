using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Contexts;

public class TobetoPlatformContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AnnouncementsNewsCategory> AnnouncementsNewsCategorys { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<AsyncContent> AsyncContents { get; set; }
    public DbSet<AsyncCourse> AsyncCourses { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<AsyncLessonsOfContent> AsyncLessonsOfContents { get; set; }
    public DbSet<AsyncLessonsDetail> AsyncLessonsDetails { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CourseDetail> CourseDetails { get; set; }
    public DbSet<CourseExam> CourseExams { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<LiveContent> LiveContents { get; set; }
    public DbSet<LiveCourse> LiveCourses { get; set; }
    public DbSet<PasswordReset> PasswordReset { get; set; }
    public DbSet<PersonalInfo> PersonalInfos { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<SocialAccount> SocialAccounts { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public TobetoPlatformContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration; 
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}


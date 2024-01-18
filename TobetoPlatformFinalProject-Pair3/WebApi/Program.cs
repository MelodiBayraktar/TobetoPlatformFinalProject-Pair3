using System.Configuration;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Core.Extensions;
using Business;
using DataAccess;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //AutoFac Ekleme kısmı
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(
        builder => builder.RegisterModule(new AutofacBusinessModule()));

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddBusinessServices();
        builder.Services.AddDataAccessServices(builder.Configuration);

        //var services = builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
        //HttpContextAccessor, client tarafından atılan requestin be tarafında response oluşturulup dönene kadar
        //olan tüm süreci takip etmeye yarar.

        var configuration = builder.Configuration;
        var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });

        builder.Services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy("CorsPolicy",
        //        builder => builder
        //            .WithOrigins("http://localhost:3000")
        //            .AllowAnyMethod()
        //            .AllowAnyHeader()
        //            .AllowCredentials());
        //});

        builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(setup =>
        {

            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"

            });
            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }

            },
            new List<string>()
        }
    });
        });
    
        //Autofac, Ninject,CastleWindsor, StructureMap, LightInject, DryInject --> IoC Container
        //AOP

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        //app.UseHttpsRedirection();

        //app.UseCors("CorsPolicy");

        app.Run();
    }
}
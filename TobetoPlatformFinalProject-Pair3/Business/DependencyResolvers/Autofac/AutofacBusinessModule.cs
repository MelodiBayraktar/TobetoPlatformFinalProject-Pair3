using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;

using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<UserManager>().As<IUserService>();
        //builder.RegisterType<EfUserDal>().As<IUserDal>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}
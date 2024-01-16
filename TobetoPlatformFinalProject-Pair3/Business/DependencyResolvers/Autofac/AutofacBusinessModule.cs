using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;

using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<UserManager>().As<IUserService>();
        //builder.RegisterType<EfUserDal>().As<IUserDal>();


        //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
        //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
        //    {
        //        Selector = new AspectInterceptorSelector()
        //    }).SingleInstance();

    }
}
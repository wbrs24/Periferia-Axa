using AppServices.Interfaces;
using AppServices.Services;
using AppUtilities;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Model.Profiles;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AxaAssistance.App_Start
{
    public static class DIConfig
    {
        public static IContainer Container { get; set; }
        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            RegisterControllers(builder);
            RegisterMappings(builder);

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<AccountService>().As<IAccountService>().SingleInstance();

            builder.RegisterType<Utilities>().As<IUtilities>().SingleInstance();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().SingleInstance();
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
        private static void RegisterMappings(ContainerBuilder builder)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new UserRegisterProfile());
                cfg.AddProfile(new RolProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
        }
        
    }
}
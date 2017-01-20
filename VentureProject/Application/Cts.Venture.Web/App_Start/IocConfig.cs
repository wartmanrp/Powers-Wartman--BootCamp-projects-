//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Reflection;
//using Autofac;
//using Cts.Venture.Domain.Services;
//using Cts.Venture.Domain;

//namespace Cts.Venture.Web
//{
//    public class IocConfig
//    {
//        public static void RegisterTypes(ContainerBuilder builder)
//        {
//            builder.RegisterType<GamesEntities>()
//                .InstancePerLifetimeScope();

//            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
//                .Where(x => x.Name.EndsWith("Handler"))
//                .AsImplementedInterfaces();

//            builder.RegisterType<AuthService>()
//                .As<IAuthService>();
            
//            builder.Register(x => new HttpContextWrapper(HttpContext.Current))
//                .As<HttpContextBase>();
//        }
//    }
//}
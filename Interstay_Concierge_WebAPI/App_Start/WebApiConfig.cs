using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.Repositories;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using DataAccess.Services;
using Interstay_Concierge_WebAPI.Resolver;
using Unity;
using Microsoft.Owin.Security.OAuth;

namespace Interstay_Concierge_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            
            container.RegisterType<IConnectionFactory, ConnectionFactory>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IMessageTypeRepository, MessageTypeRepository>();
            container.RegisterType<IMessageRepository, MessageRepository>();
                        
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUnitOfWorkMessageType, UnitOfWorkMessageType>();
            container.RegisterType<IUnitOfWorkMessage, UnitOfWorkMessage>();
                        
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMessageTypeService, MessageTypeService>();
            container.RegisterType<IMessageService, MessageService>();

            config.DependencyResolver = new UnityResolver(container);

            // Web API 구성 및 서비스
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

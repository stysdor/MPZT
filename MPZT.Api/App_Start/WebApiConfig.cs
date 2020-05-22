using AutoMapper;
using MPZT.Api.ioc;
using MPZT.Infrustructure.Mappers;
using MPZT.Infrustructure.Repositories;
using MPZT.Infrustructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Cors;

namespace MPZT.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "ControllerAndActionId",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "aplication/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //dependency Injection
            var container = new UnityContainer();
            container.RegisterType<IAreaService, AreaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProposalService, ProposalService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectService, ProjectService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IMapper>(AutoMapperConfig.Initialize());
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}

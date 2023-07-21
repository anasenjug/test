using Autofac;
using Autofac.Integration.WebApi;
using example.repository;
using example.services;
using example.webapi.Controllers;
using Microsoft.Ajax.Utilities;
using repository.common;
using services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace example.webapi.App_Start
{
    public class ContainerConfig
    {
        public IContainer Configure(string connectionString) { 

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterInstance(connectionString).As<string>();
            builder.RegisterType<TheaterRepository>().As<IRepository>();
            builder.RegisterType<TheaterServices>().As<IServices>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }    
        
    }
}
using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Facade.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Student.Business.Facade.App_Start
{
    public class AutofacConfigure  //es el que resuelve todas las clases registradas
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new StudentApiModules());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}
using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Logic.BusinessLogic;
using Student.Business.Logic.Modules;
using Student.Common.Logic.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Student.Business.Facade.Modules
{
    public class StudentApiModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                 .RegisterType<StudentBL>()
                 .As<IBusiness>()
                 .InstancePerRequest();

            builder
                 .RegisterType<Log4netAdapter>()
                 .As<ILogger>()
                 .InstancePerRequest();

            builder.RegisterModule(new BusinessModule());

            base.Load(builder);
        }
    }
}
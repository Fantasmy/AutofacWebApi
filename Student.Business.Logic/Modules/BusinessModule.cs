using Autofac;
using Student.Common.Logic.Log4net;
using Student.DataAccess.Dao.Interfaces;
using Student.DataAccess.Dao.Modules;
using Student.DataAccess.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder) // registramos los tipos que se instancian en runtime
        {
            builder
                 .RegisterType<StudentDaoSql>()
                 .As<IRepository>()
                 .InstancePerRequest();

            builder
                 .RegisterType<Log4netAdapter>()
                 .As<ILogger>()
                 .InstancePerRequest();

            builder.RegisterModule(new StudentDaoModules());  // se instancia de la capa de abajo

            base.Load(builder);
        }
    }
}

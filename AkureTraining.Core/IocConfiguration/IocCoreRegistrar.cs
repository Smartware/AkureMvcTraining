using SmartWr.WebFramework.Library.Infrastructure.TypeFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SmartWr.WebFramework.Library.Infrastructure.Logging;
using System.Reflection;
using AkureTraining.Core.Controllers;
using System.Web.Mvc;
using AkureTraining.Core.Context;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data;
using SmartWr.WebFramework.Library.MiddleServices.UnitOfWork;

namespace AkureTraining.Core.IocConfiguration
{
    public class IocCoreRegistrar : IDependencyRegistrar
    {
        public int Order
        {
            get { return 0; }
        }

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.Register<UnitOfWork>(x => 
            {
                var dbContext = x.Resolve<AkureTrainingDbContext>();
                var uow = new UnitOfWork(dbContext);
                return uow;

            }).As<IUnitOfWork>();

            builder.Register<AkureTrainingDbContext>(x =>
            {
                var logger = x.Resolve<ILogger>();
                var connectionnName = "name=AkureTrainingDbContext";
                return new AkureTrainingDbContext(connectionnName, logger);
            }).InstancePerDependency();

            builder.Register(x => NLogLogger.Instance).As<ILogger>().InstancePerDependency();

            var assembly = Assembly.GetAssembly(typeof(BaseMvcController));
            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);
        }

    }
}

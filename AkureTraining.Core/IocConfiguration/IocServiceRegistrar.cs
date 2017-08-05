using SmartWr.WebFramework.Library.Infrastructure.TypeFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AkureTraining.Core.Services;

namespace AkureTraining.Core.IocConfiguration
{
    public class IocServiceRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<BaseAppService>().As<BaseAppService>().InstancePerRequest();
            builder.RegisterType<ContactService>().As<ContactService>().InstancePerRequest();
            builder.RegisterType<TransactionService>().As<TransactionService>().InstancePerRequest();
            builder.RegisterType<MessagesServices>().As<MessagesServices>().InstancePerRequest();
            builder.RegisterType<AccountServices>().As<AccountServices>().InstancePerRequest();
        }
    }
}

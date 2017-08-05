using SmartWr.WebFramework.Library.Infrastructure.Logging;
using SmartWr.WebFramework.Library.MiddleServices.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AkureTraining.Core.Models;
using AkureTraining.Core.ViewModels;
using AkureTraining.Core.Models.Map;
using System.Reflection;
using SmartWr.WebFramework.Library.MiddleServices.Models.Auth;

namespace AkureTraining.Core.Context
{
    public class AkureTrainingDbContext: ApplicationDbContext
    {
        static AkureTrainingDbContext()
        {
            Database.SetInitializer<AkureTrainingDbContext>(null);
        }
        public AkureTrainingDbContext()
            : base("name=AkureTrainingDbContext", NLogLogger.Instance)
        {
            Database.SetInitializer<AkureTrainingDbContext>(null);
        }

       
        public AkureTrainingDbContext(String name, ILogger logger) :
            base(name, logger)
        {
            Database.SetInitializer<AkureTrainingDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }
        }
    }
}

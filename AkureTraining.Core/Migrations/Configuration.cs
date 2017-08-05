namespace AkureTraining.Core.Migrations
{
    using AkureTraining.Core.Models;
    using AkureTraining.Core.Services;
    using SmartWr.WebFramework.Library.Infrastructure.IoCs;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AkureTraining.Core.Migrations.DataSetup;

    internal sealed class Configuration : DbMigrationsConfiguration<AkureTraining.Core.Context.AkureTrainingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AkureTraining.Core.Context.AkureTrainingDbContext context)
        {
            UserDataSetup.CreateAdminUsers(context);
        }



    }
}

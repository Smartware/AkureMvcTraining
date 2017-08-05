namespace AkureTraining.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sp_DashboardCounter : DbMigration
    {
        public override void Up()
        {
            String tsql = @"SET DATEFORMAT dmy
Select (Select Count(*) From Contacts c WHERE c.IsDeleted = 'false' )  as TotalContacts,

(SELECT ISNULL(SUM(txn.Amounts), 0) FROM Transactions txn WHERE txn.IsDeleted = 'false'
 AND Convert(DATE,txn.CreatedOnUtc) = Convert(DATE, @todayDate)) as TodayTotalTransaction";

            CreateStoredProcedure("[dbo].[Sp_DashboardCounter]",
                t => new
                {
                    todayDate = t.DateTime()
                },
                tsql);
        }
        
        public override void Down()
        {
            DropStoredProcedure("[dbo].[Sp_DashboardCounter]");
        }
    }
}

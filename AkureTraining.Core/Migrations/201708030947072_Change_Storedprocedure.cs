namespace AkureTraining.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Change_Storedprocedure : DbMigration
    {
        public override void Up()
        {

            String tsql = @"SET DATEFORMAT dmy
SET DATEFORMAT dmy
    Select (Select Count(*) From Contacts c WHERE c.IsDeleted = 'false' )  as TotalContacts,
    
    (SELECT ISNULL(SUM(txn.Amounts), 0) FROM Transactions txn WHERE txn.IsDeleted = 'false'
    AND Convert(DATE,txn.CreatedOnUtc) = Convert(DATE, @todayDate)) as TodayTotalTransaction,

	 (SELECT Count(*) From dbo.Messages c WHERE c.IsDeleted = 'false' )  as TotalmessageSent,


	(SELECT Count(*) From dbo.Messages c WHERE c.IsDeleted = 'false' )  as TotalmessageSent,


	 (SELECT ISNULL(SUM(Sms_Balance), 0) FROM Accounts acct WHERE acct.IsDeleted = 'false'
  AND Convert(DATE,acct.CreatedOnUtc) = Convert(DATE, @todayDate)) as SmsUnitBalance";

            AlterStoredProcedure("[dbo].[Sp_DashboardCounter]",
                t => new
                {
                    todayDate = t.DateTime()
                },
                tsql);
        }

        public override void Down()
        {
            String tsql = @"SET DATEFORMAT dmy
Select (Select Count(*) From Contacts c WHERE c.IsDeleted = 'false' )  as TotalContacts,

(SELECT ISNULL(SUM(txn.Amounts), 0) FROM Transactions txn WHERE txn.IsDeleted = 'false'
 AND Convert(DATE,txn.CreatedOnUtc) = Convert(DATE, @todayDate)) as TodayTotalTransaction";

            AlterStoredProcedure("[dbo].[Sp_DashboardCounter]",
                t => new
                {
                    todayDate = t.DateTime()
                },
                tsql);
        }
    }
}

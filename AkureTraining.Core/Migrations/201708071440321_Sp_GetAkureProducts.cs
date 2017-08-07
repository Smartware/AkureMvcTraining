namespace AkureTraining.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Sp_GetAkureProducts : DbMigration
    {
        string procedureName = "[dbo].[Sp_GetAkureProducts]";
        String tsql = @"SET NOCOUNT ON;
                         WITH dbResult
                       AS(SELECT Row_number()
                                    OVER (ORDER BY p.ModifiedOnUtc DESC, p.EntryDate DESC) RowNumber,
                                  Count(*) OVER() TotalCount,
								  p.ProductId,
								  p.Barcode,
								  p.CanExpire,
								  p.ExpiryDate,
								  p.NAME,
								  p.Quantity,
								  p.IsDiscountable,
								  p.Price,
								  p.ProductUId
                           FROM   Product p
                           WHERE  ((@Keyword IS NULL
                                     OR p.NAME LIKE '%' + @Keyword + '%'
                                     OR p.[Description] LIKE  '%' + @Keyword + '%'
                                     OR p.ProductId LIKE @Keyword
                                     OR p.Price LIKE @Keyword
                                     OR p.Barcode LIKE '%' + @Keyword + '%')
									  AND p.isdeleted = 0))
                          SELECT *
                          FROM   dbResult
                          WHERE  RowNumber BETWEEN(@ItemsPerPage* (@PageIndex - 1 ) ) + 1 AND(@ItemsPerPage* @PageIndex)";
        public override void Up()
        {
            CreateStoredProcedure(procedureName, t => new
            {
                Keyword = t.String(),
                PageIndex = t.Int(),
                ItemsPerPage = t.Int()

            }, tsql);
        }

        public override void Down()
        {
            DropStoredProcedure(procedureName);
        }
    }
}

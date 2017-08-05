using AkureTraining.Core.Dtos;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data;
using SmartWr.WebFramework.Library.MiddleServices.Models;
using SmartWr.WebFramework.Library.MiddleServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.Services
{
    public class BaseAppService : Service<BaseEntity>
    {
        public BaseAppService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<ProductDto> GetAkureProducts(String keywords, Int32? pageIndex, Int32? pageSize)
        {
            var tsql = "Exec [dbo].[Sp_GetAkureProducts] @p0, @p1, @p2";
            return this.UnitOfWork.Repository<ProductDto>().SqlQuery(tsql, keywords, pageIndex, pageSize);
        }


        public List<DashboardCounterDto> GetDashboardCounter(DateTime todayDate)
        {
            var tsql = "Exec [dbo].[Sp_DashboardCounter] @p0";
            return this.UnitOfWork.Repository<DashboardCounterDto>().SqlQuery(tsql, todayDate).ToList();
        }
    }
}

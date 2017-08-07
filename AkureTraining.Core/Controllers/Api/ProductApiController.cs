using AkureTraining.Core.Services;
using AkureTraining.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AkureTraining.Core.Controllers.Api
{
    [RoutePrefix("api/productapi")]
    public class ProductApiController : ApiController
    {
        private BaseAppService _baseAppSvc;

        public ProductApiController(BaseAppService baseAppSvc)
        {
            _baseAppSvc = baseAppSvc;
        }

        [Route("list")]
        public HttpResponseMessage ProductList(ProductSearchViewModel searchModel)
        {
            ApiResult<List<ProductViewModel>> response = new ApiResult<List<ProductViewModel>>();

           var productList = _baseAppSvc.GetAkureProducts(searchModel.Keywords,
               searchModel.PageIndex, searchModel.PageSize).ToList();

            List<ProductViewModel> prodVmList = new List<ProductViewModel>();

            productList.ForEach(p => 
            {

                prodVmList.Add(new ProductViewModel()
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    Price = p.Price.HasValue? p.Price.Value.ToString(): "[NA]" ,
                    Quantity = p.Quantity.HasValue? p.Quantity.Value.ToString(): "[NA]",
                    TotalCount = p.TotalCount
                });
            });

            response.Result = prodVmList;
 
            return this.Request.CreateResponse(response);
        }
    }
}

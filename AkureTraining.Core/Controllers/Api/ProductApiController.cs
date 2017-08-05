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
        [Route("list")]
        public HttpResponseMessage ProductList()
        {

            return this.Request.CreateResponse(new List<Int32>() { 1, 3, 8, 763, 83 });
        }
    }
}

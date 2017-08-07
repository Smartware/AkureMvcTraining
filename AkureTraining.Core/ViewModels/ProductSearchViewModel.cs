using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.ViewModels
{
   public class ProductSearchViewModel: BaseViewModel
    {
        public String Keywords { get; set; }
        public Int32? PageIndex { get; set; }
        public Int32? PageSize { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Price { get; set; }
        public String Quantity { get; set; }
        public Int32 TotalCount { get; set; }
    }
}

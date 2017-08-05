using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.Infrastructure.Validation;

namespace AkureTraining.Core.Dtos
{
    public class ProductDto : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public Int32? Quantity { get; set; } 
        public Decimal? Price { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }

        public override List<ValidationError> Validate()
        {
            return ValidationErrors;
        }
    }
}

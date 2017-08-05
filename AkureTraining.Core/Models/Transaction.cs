using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.Infrastructure.Validation;

namespace AkureTraining.Core.Models
{
    public class Transaction : BaseEntity
    {
        public String TxnNo { get; set; }
        public Decimal Units { get; set; }
        public Decimal Amounts { get; set; }
        public Decimal Rate { get; set; }
        public DateTime TxnDate { get; set; }
        public Int32 Status { get; set; }
        public override List<ValidationError> Validate()
        {
            if (Amounts < 0)
            {
                this.ValidationErrors.Add(new ValidationError("Amounts", "Amount cannot be less than zero"));
            }

            return this.ValidationErrors;
        }
    }
}

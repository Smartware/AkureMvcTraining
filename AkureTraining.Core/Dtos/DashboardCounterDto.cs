using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.Infrastructure.Validation;

namespace AkureTraining.Core.Dtos
{
    public class DashboardCounterDto : BaseEntity
    {
        public Int32 TotalContacts { get; set; }
        public Decimal TodayTotalTransaction { get; set; }
        public Int32 TotalmessageSent { get; set; }
        public Decimal SmsUnitBalance { get; set; }

        public override List<ValidationError> Validate()
        {
            return this.ValidationErrors;
        }
    }
}

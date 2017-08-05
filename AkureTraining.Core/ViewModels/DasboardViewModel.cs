using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.ViewModels
{
    public class DasboardViewModel: BaseViewModel
    {
        public Int32 TotalContacts { get; set; }
        public Decimal TodayTotalTransaction { get; set; }
        public Int32 TotalmessageSent { get; set; }
        public Decimal SmsUnitBalance { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        public int id { get; internal set; }
        public string TxtNo { get; internal set; }
        public DateTime TxnDate { get; internal set; }
        public decimal Amounts { get; internal set; }
        public decimal Rate { get; internal set; }
    }
}

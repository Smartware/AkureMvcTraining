using AkureTraining.Core.Models;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data;
using SmartWr.WebFramework.Library.MiddleServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.Services
{
    public class TransactionService : Service<Transaction>
    {
        public TransactionService(IUnitOfWork uow) : base(uow)
        {
        }

        public List<Transaction> GetTransactions()
        {
            return this.GetAll();
        }
    }
}

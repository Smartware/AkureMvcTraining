using AkureTraining.Core.Models;
using SmartWr.WebFramework.Library.MiddleServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data;

namespace AkureTraining.Core.Services
{
    public class AccountServices : Service<Account>
    {
        public AccountServices(IUnitOfWork uow) : base(uow)
        {

        }
    }
}

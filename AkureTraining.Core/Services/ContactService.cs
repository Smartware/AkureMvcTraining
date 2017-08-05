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
   public class ContactService: Service<Contact>
    {
        public ContactService(IUnitOfWork uow): base(uow)
        {

        }
    }
}

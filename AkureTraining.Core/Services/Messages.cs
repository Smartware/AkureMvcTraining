using SmartWr.WebFramework.Library.Infrastructure.Validation;
using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.Services
{
    public class Messages : BaseEntity
    {

        public String Recipient_Name { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
        

        public override List<ValidationError> Validate()
        {
            if (String.IsNullOrEmpty(Recipient_Name))
            {
                this.ValidationErrors.Add(
                    new ValidationError("Recipient_Name ", " Recipient name is required"));
            }
            if (String.IsNullOrEmpty(Subject))
            {
                this.ValidationErrors.Add(
                    new ValidationError("Subject ", " Subject is important"));
            }

            return this.ValidationErrors;

        }
    }
}

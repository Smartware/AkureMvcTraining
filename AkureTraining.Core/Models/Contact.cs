using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.Infrastructure.Validation;

namespace AkureTraining.Core.Models
{
    public class Contact : BaseEntity
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime DoB { get; set; }


        public override List<ValidationError> Validate()
        {
            if (String.IsNullOrEmpty(LastName) && String.IsNullOrEmpty(FirstName))
            {
                this.ValidationErrors.Add(
                    new ValidationError("LastName", "Either first name or last name  are required"));
            }

            return this.ValidationErrors;

        }
    }
}

using SmartWr.WebFramework.Library.Infrastructure.Validation;
using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.Models
{
    public class Account : BaseEntity
    {

        public Int32 CustomerId { get; set; }
        public String Customer_Name { get; set; }
        public decimal Credit_Loaded { get; set; }
         public decimal Sms_Balance { get; set; }
           


            public override List<ValidationError> Validate()
            {
                if (String.IsNullOrEmpty(Customer_Name))
                {
                    this.ValidationErrors.Add(
                        new ValidationError("Customer_Name ", " Customer Name is required"));
                }
                if (Credit_Loaded <0)
                {
                    this.ValidationErrors.Add(
                        new ValidationError("Credit Loaded ", " Credit Loaded cannot be negative"));
                }

                return this.ValidationErrors;

            }
        }
    }
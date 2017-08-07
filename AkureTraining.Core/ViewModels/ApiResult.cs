using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.ViewModels
{
    public class ApiResult<T> : BaseViewModel
    {
        public ApiResult()
        {
            Result = default(T);
        }
        //public Boolean ErrorStatus
        //{
        //    get
        //    {
        //        return base.HasError;
        //    }
            
        //}
        public override String ErrorMessage
        {
            get
            {
                return base.ErrorMessage;
            }
            set
            {
                base.ErrorMessage = value;
            }
        }
        public String Message { get; set; }
        public T Result { get; set; } = default(T);
        public dynamic AdditionalResult { get; set; }
    }
}

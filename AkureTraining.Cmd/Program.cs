using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Cmd
{
    [AuthorizeAttribute()]
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class AuthorizeAttribute : Attribute
    {
        public AuthorizeAttribute(String val1 = "", String val2 = "")
        {

        }
    }
}

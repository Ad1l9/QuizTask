using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Exceptions
{
    internal class TrueVariantAlreadyExistException:Exception
    {
        public TrueVariantAlreadyExistException(string message = "True variant already exists") : base(message)
        {

        }
    }
}

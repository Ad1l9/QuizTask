using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20.Models
{
    internal class Variant
    {

        public Variant (string variant, bool isTrue)
        {
            VariantName = variant;
            IsTrue = isTrue;
        }

        public string VariantName { get; set; }

        public bool IsTrue { get; set; }

        public override string ToString()
        {
            return VariantName;
        }
    }
}

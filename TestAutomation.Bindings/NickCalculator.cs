using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Bindings
{
    public class NickCalculator
    {
        public decimal Add(decimal a, decimal b)
        {
            var c = a + b;
            return c;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            var c = b - a;
            return c;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomation.Bindings
{
    public class Calculator
    {
        public decimal Add(decimal a, decimal b)
        {
            var c = a + b;
            return c;
        } 
    }
}

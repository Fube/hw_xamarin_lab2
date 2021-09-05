using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public abstract class Operation
    {
        protected Func<decimal, decimal, decimal> Logic;

        protected Operation(Func<decimal, decimal, decimal> logic)
        {
            Logic = logic;
        }

        public abstract decimal Run(decimal? a, decimal? b);
    }
}

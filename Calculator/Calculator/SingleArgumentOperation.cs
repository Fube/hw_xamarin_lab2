using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class SingleArgumentOperation : Operation
    {
        public SingleArgumentOperation(Func<decimal, decimal, decimal> logic) : base(logic)
        {
        }

        public override decimal Run(decimal? a, decimal? b)
        {
            if (a == null) return 0;
            if (b != null) throw new Exception("Only one argument expected, got two");

            return Logic.Invoke(a.Value, 0);
        }
    }
}

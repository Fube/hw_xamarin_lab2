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

            return Logic.Invoke(a.Value, 0);
        }
    }
}

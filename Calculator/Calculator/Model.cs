using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Model
    {

        public readonly static Operation ADD = new DoubleArgumentOperation((a, b) => a + b);
        public readonly static Operation SUB = new DoubleArgumentOperation((a, b) => a - b);
        public readonly static Operation MUL = new DoubleArgumentOperation((a, b) => a * b);
        public readonly static Operation DIV = new DoubleArgumentOperation((a, b) => a / b);
        public readonly static Operation PRC = new DoubleArgumentOperation((a, b) => a * b / 100);

        public readonly static Operation SQR = new SingleArgumentOperation((a, b) => (decimal)Math.Sqrt((double) a));
        public readonly static Operation DBL = new SingleArgumentOperation((a, b) => a * 2);

        public decimal? FirstNum;
        public decimal? SecondNum;
        public decimal? Result;
        public Operation Op;

        public Model()
        {
            Op = new SingleArgumentOperation((a, b) => 0);
        }

        public void Reset()
        {
            FirstNum = SecondNum = null;
            Op = null;
            Result = null;
        }

        public decimal? Calculate()
        {
            if (Op == null) return null;
            if (FirstNum == null && SecondNum == null) return null;

            if(Op == PRC)
            {
                SecondNum = Op.Run(FirstNum, SecondNum);
            }

            Result = Op.Run(FirstNum, SecondNum);

            return Result;
        }
    }
}

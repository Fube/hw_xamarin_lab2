using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Model
    {
        public enum Operation
        {
            ADD,
            SUBTRACT,
            DIVIDE,
            MULTIPLY,
            SQUARE_ROOT,
            PERCENTAGE
        }

        public decimal? FirstNum;
        public decimal? SecondNum;
        public decimal? Result;
        public Operation? Op;

        public void Reset()
        {
            FirstNum = SecondNum = null;
            Op = null;
            Result = null;
        }

        public decimal? Calculate()
        {

            if(FirstNum != null && SecondNum != null)
            {
                switch (Op) 
                {
                    case Operation.ADD:
                        return FirstNum + SecondNum;
                    case Operation.SUBTRACT:
                        return FirstNum - SecondNum;
                    case Operation.DIVIDE:
                        return FirstNum / SecondNum;
                    case Operation.MULTIPLY:
                        return FirstNum * SecondNum;
                }

            }

            return null;
        }
    }
}

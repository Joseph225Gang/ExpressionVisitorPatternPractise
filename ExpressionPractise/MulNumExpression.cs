using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPractise
{
    public class MulNumExpression : ICalElement
    {
        public void Accept(int x, int y)
        {
            Expression<Func<int, int, int>> multipleNum = (num1, num2) => num1 * num2;
            var executeSimpleMul = multipleNum.Compile();
            Console.WriteLine(executeSimpleMul(x, y));
        }

    }
}

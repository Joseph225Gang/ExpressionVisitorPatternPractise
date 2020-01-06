using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPractise
{
    public class AddNumExpression : ICalElement
    {

        public void Accept(int x, int y)
        {
            Expression<Func<int, int, int>> addNum = (num1, num2) => num1 + num2;
            var executeSimpleAdd = addNum.Compile();
            Console.WriteLine(executeSimpleAdd(x, y));
        }
    }
}

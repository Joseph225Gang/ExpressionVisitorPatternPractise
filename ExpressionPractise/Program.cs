using System;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimpleExpressionVisitor simpleVisitor = new SimpleNumVisitor();
            ISimpleExpressionVisitor overTenVisitor = new OverTenVisitor();
            var addExp = new AddNumExpression();
            var mulExp = new MulNumExpression();

            simpleVisitor.Visit(addExp);
            simpleVisitor.Visit(mulExp);

            overTenVisitor.Visit(addExp);
            overTenVisitor.Visit(mulExp);
            Console.WriteLine();
        }

    }
}

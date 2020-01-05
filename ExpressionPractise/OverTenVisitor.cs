using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionPractise
{
    public class OverTenVisitor : ISimpleExpressionVisitor
    {
        public void Visit(AddNumExpression addExp)
        {
            addExp.Accept(10, 20);
        }

        public void Visit(MulNumExpression mulExp)
        {
            mulExp.Accept(10, 20);
        }
    }
}

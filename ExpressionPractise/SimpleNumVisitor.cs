using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionPractise
{
    public class SimpleNumVisitor : ISimpleExpressionVisitor
    {
        public void Visit(AddNumExpression addExp)
        {
            addExp.Accept(2, 3);
        }

        public void Visit(MulNumExpression mulExp)
        {
            mulExp.Accept(2, 3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionPractise
{
    public interface ISimpleExpressionVisitor
    {
        void Visit(AddNumExpression addExp);
        void Visit(MulNumExpression mulExp);
    }
}

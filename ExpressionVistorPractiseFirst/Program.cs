using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionVistorPractiseFirst
{
	public class Program
	{
		public static void Main()
		{
			var colourRepository = new ColourRepository();
			var result = colourRepository.GetWhere(c => c.Name == "Red");

			Console.WriteLine(result.Count());
		}
	}

	public class DtoColour
	{

		public DtoColour(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}

	public class DomainColour
	{

		public DomainColour(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}

	public class ColourRepository
	{

		private IList<DtoColour> Colours { get; set; }

		public ColourRepository()
		{
			Colours = new List<DtoColour>()
				{
					new DtoColour("Red"),
					new DtoColour("Blue"),
					new DtoColour("Yellow")
				};
		}

		public IEnumerable<DomainColour> GetWhere(Expression<Func<DomainColour, bool>> predicate)
		{
			var coonvertedPred = MyExpressionVisitor.Convert(predicate);
			return Colours.Where(coonvertedPred).Select(c => new DomainColour(c.Name)).ToList();
		}
	}

	public class MyExpressionVisitor : ExpressionVisitor
	{
		private ReadOnlyCollection<ParameterExpression> _parameters;

		public static Func<DtoColour, bool> Convert<T>(Expression<T> root)
		{
			var visitor = new MyExpressionVisitor();
			var expression = (Expression<Func<DtoColour, bool>>)visitor.Visit(root);
			return expression.Compile();
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			return (_parameters != null) ? _parameters.FirstOrDefault(p => p.Name == node.Name) :
				   (node.Type == typeof(DomainColour) ? Expression.Parameter(typeof(DtoColour), node.Name) : node);
		}

		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			_parameters = VisitAndConvert<ParameterExpression>(node.Parameters, "VisitLambda");
			return Expression.Lambda(Visit(node.Body), _parameters);
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (node.Member.DeclaringType == typeof(DomainColour))
			{
				return Expression.MakeMemberAccess(Visit(node.Expression), typeof(DtoColour).GetProperty(node.Member.Name));
			}
			return base.VisitMember(node);
		}
	}
}

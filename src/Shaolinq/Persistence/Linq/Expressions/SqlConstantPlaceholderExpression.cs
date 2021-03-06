// Copyright (c) 2007-2017 Thong Nguyen (tumtumtum@gmail.com)

using System.Linq.Expressions;

namespace Shaolinq.Persistence.Linq.Expressions
{
	public class SqlConstantPlaceholderExpression
		: SqlBaseExpression
	{
		public int Index { get; }
		public ConstantExpression ConstantExpression { get; }
		public override ExpressionType NodeType => (ExpressionType)SqlExpressionType.ConstantPlaceholder;

		public SqlConstantPlaceholderExpression(int index, ConstantExpression constantExpression)
			: base(constantExpression.Type)
		{
			this.Index = index;
			this.ConstantExpression = constantExpression;
		}

		public SqlConstantPlaceholderExpression ChangeConstant(ConstantExpression expression)
		{
			return new SqlConstantPlaceholderExpression(this.Index, expression);
		}
	}
}

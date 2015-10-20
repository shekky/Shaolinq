﻿// Copyright (c) 2007-2015 Thong Nguyen (tumtumtum@gmail.com)

using System.Collections.Generic;
using System.Linq.Expressions;
using Platform.Collections;

namespace Shaolinq.Persistence.Linq.Expressions
{
	public class SqlEnumDefinitionExpression
		: SqlBaseExpression
	{
		public IReadOnlyList<string> Labels { get; }
		public override ExpressionType NodeType => (ExpressionType)SqlExpressionType.EnumDefinition;

		public SqlEnumDefinitionExpression(IEnumerable<string> labels)
			: this(labels.ToReadOnlyList())
		{	
		}

		public SqlEnumDefinitionExpression(IReadOnlyList<string> labels)
			: base(typeof(void))
		{
			this.Labels = labels;
		}
	}
}

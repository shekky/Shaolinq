// Copyright (c) 2007-2017 Thong Nguyen (tumtumtum@gmail.com)

using System;
using System.Data;
using Platform;
using Shaolinq.Persistence;

namespace Shaolinq.Sqlite
{
	public class SqliteSqlDataTypeProvider
		: DefaultSqlDataTypeProvider
	{
		public SqliteSqlDataTypeProvider(ConstraintDefaultsConfiguration constraintDefaultsConfiguration)
			: base(constraintDefaultsConfiguration)
		{
			this.DefinePrimitiveSqlDataType(typeof(byte), "INTEGER", "GetByte");
			this.DefinePrimitiveSqlDataType(typeof(sbyte), "INTEGER", "GetByte");
			this.DefinePrimitiveSqlDataType(typeof(char), "TEXT", "GetChar");
			this.DefinePrimitiveSqlDataType(typeof(int), "INTEGER", "GetInt32");
			this.DefinePrimitiveSqlDataType(typeof(uint), "INTEGER", "GetInt32");
			this.DefinePrimitiveSqlDataType(typeof(short), "INTEGER", "GetInt16");
			this.DefinePrimitiveSqlDataType(typeof(ushort), "INTEGER", "GetUInt16");
			this.DefinePrimitiveSqlDataType(typeof(long), "INTEGER", "GetInt64");
			this.DefinePrimitiveSqlDataType(typeof(ulong), "INTEGER BIGINT", "GetUInt64");
			this.DefinePrimitiveSqlDataType(typeof(DateTime), "TEXT", "GetDateTime");
			this.DefinePrimitiveSqlDataType(typeof(float), "REAL", "GetFloat");
			this.DefinePrimitiveSqlDataType(typeof(double), "REAL", "GetDouble");
			this.DefinePrimitiveSqlDataType(typeof(decimal), "TEXT", "GetDecimal");
		}
	}
}

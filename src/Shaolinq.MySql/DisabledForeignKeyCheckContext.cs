// Copyright (c) 2007-2017 Thong Nguyen (tumtumtum@gmail.com)

using Shaolinq.Persistence;

namespace Shaolinq.MySql
{
	internal class DisabledForeignKeyCheckContext
		: IDisabledForeignKeyCheckContext
	{
		private readonly SqlTransactionalCommandsContext context;

		public DisabledForeignKeyCheckContext(SqlTransactionalCommandsContext context)
		{
			this.context = context;

			using (var command = ((DefaultSqlTransactionalCommandsContext)context).CreateCommand())
			{

				command.CommandText = "SET FOREIGN_KEY_CHECKS = 0;";

				command.ExecuteNonQuery();
			}
		}

		public virtual void Dispose()
		{
			using (var command = ((DefaultSqlTransactionalCommandsContext)this.context).CreateCommand())
			{

				command.CommandText = "SET FOREIGN_KEY_CHECKS = 1;";

				command.ExecuteNonQuery();
			}
		}
	}
}

﻿using Platform.Xml.Serialization;

namespace Shaolinq.Persistence.Sql.DevartPostgres
{
	[XmlElement]
	public class DevartPostgresPersistenceContextInfo
		: PersistenceContextInfo
	{
		[XmlAttribute]
		public string DatabaseName { get; set; }

		[XmlElement("Connections")]
		[XmlListElement(typeof(DevartPostgresDatabaseConnectionInfo), "Connection")]
		public DevartPostgresDatabaseConnectionInfo[] DatabaseConnectionInfos { get; set; }

		public override string PersistenceContextName
		{
			get { return this.DatabaseName; }
			set { this.DatabaseName = value; }
		}

		public override PersistenceContextProvider NewDatabaseContextProvider()
		{
			return new DevartPostgresPersistenceContextProvider(this.ContextName, this.DatabaseName, this.DatabaseConnectionInfos);
		}
	}
}
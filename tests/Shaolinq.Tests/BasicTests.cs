﻿using System;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using Shaolinq.Persistence.Sql.Sqlite;
using Shaolinq.Tests.DataAccessModel.KungFuSchool;
using log4net.Config;

namespace Shaolinq.Tests
{
	[TestFixture]
	public class BasicTests
	{
		protected KungFuSchoolDataAccessModel model;

		[SetUp]
		public virtual void SetUp()
		{
			XmlConfigurator.Configure();

			var configuration = new DataAccessModelConfiguration()
			{
				PersistenceContexts = new PersistenceContextInfo[]
				{
					new SqlitePersistenceContextInfo()
					{
						ContextName = "KungFuSchool",
						DatabaseName = "KungFuSchool",
						DatabaseConnectionInfos = new SqliteDatabaseConnectionInfo[]
						{
							new SqliteDatabaseConnectionInfo()
							{
								PersistenceMode = PersistenceMode.ReadWrite,
								FileName = "KungFuSchool.db"
							}
						}
					}
				}
			};

			model = BaseDataAccessModel.BuildDataAccessModel<KungFuSchoolDataAccessModel>(configuration);

			model.CreateDatabases(true);
		}

		[Test]
		public void Test_Create_Object_And_Related_Object_Then_Query()
		{
			Guid studentId;

			using (var scope = new TransactionScope())
			{
				var school = model.Schools.NewDataAccessObject();

				school.Name = "The Shaolinq School of Kung Fu";
				
				var student = school.Students.NewDataAccessObject();
				
				student.Birthdate = new DateTime(1940, 11, 27);
				student.FirstName = "Bruce";
				student.LastName = "Lee";

				Assert.AreEqual(school, student.School);
				Assert.AreEqual(student.FirstName + " " + student.LastName, student.FullName);

				scope.Flush(model);

				studentId = student.Id;
				
				scope.Complete();
			}

			using (var scope = new TransactionScope())
			{
				var student = this.model.ReferenceToDataAccessObject<Student>(studentId);

				Assert.IsTrue(student.IsWriteOnly);
				
				Assert.Catch(typeof(WriteOnlyDataAccessObjectException), () => Console.WriteLine(student.FirstName));

				scope.Complete();				
			}

			var students = model.Students.Where(c => c.FirstName == "Bruce").ToList();

			Assert.AreEqual(1, students.Count);

			var storedStudent = students.First();

			Assert.AreEqual("Bruce Lee", storedStudent.FullName);
		}
	}
}
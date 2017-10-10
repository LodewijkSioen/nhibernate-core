﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace NHibernate.Test.NHSpecificTest.NH1904
{
	using System.Threading.Tasks;
	[TestFixture]
	public class FixtureAsync : BugTestCase
	{
		[Test]
		public async Task ExecuteQueryAsync()
		{
			using (ISession session = OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				Invoice invoice = new Invoice();
				invoice.Issued = DateTime.Now;

				await (session.SaveAsync(invoice));
				await (transaction.CommitAsync());
			}

			using (ISession session = OpenSession())
			{
				IList<Invoice> invoices = await (session.CreateCriteria<Invoice>().ListAsync<Invoice>());
			}
		}

		protected override void OnTearDown()
		{
			base.OnTearDown();
			using (ISession session = OpenSession())
			{
				session.CreateQuery("delete from Invoice").ExecuteUpdate();
				session.Flush();
			}
		}
	}
}
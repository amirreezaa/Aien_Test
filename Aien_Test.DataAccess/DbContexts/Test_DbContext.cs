using System;
using System.Reflection;
using Aien_Test.Common.Utilities;
using Aien_Test.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Aien_Test.DataAccess.DbContexts
{
	public class Test_DbContext : DbContext
	{
		public Test_DbContext(DbContextOptions<Test_DbContext> options)
			:base(options)
		{
		}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			Assembly domainAssembly = typeof(BaseEntity).Assembly;

			modelBuilder.RegisterAllEntities<BaseEntity>(domainAssembly);
			modelBuilder.RegisterEntityTypeConfiguration(domainAssembly);
        }
    }
}


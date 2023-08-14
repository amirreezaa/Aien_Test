using System;
using Aien_Test.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aien_Test.WebFramework.Configuration
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Test_DbContext>(options =>
            {
                options
                    .UseSqlServer(configuration.GetConnectionString("Aien_Test_Connection"));
            });
        }
    }
}


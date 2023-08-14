using System;
using Aien_Test.DataAccess.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Aien_Test.Application.Services.Interfaces;

namespace Aien_Test.WebFramework.Configuration
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder builder)
        {

            using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var dbContext = scope.ServiceProvider.GetService<Test_DbContext>();
            dbContext.Database.Migrate();


            var dataInitializers = scope.ServiceProvider.GetService<IDataInitializer>();
            if (dataInitializers is not null)
                dataInitializers.InitializeContractData();

            return builder;
        }
    }
}


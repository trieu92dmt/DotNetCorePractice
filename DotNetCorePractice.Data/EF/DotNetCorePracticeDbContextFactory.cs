using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DotNetCorePractice.Data.EF
{
    public class DotNetCorePracticeDbContextFactory : IDesignTimeDbContextFactory<DotNetCorePracticeDbContext>
    {
        //Create DbContext
        public DotNetCorePracticeDbContext CreateDbContext(string[] args)
        {
            //Get setting file
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //Get value in setting file
            var connectionString = configuration.GetConnectionString("DotNetCoreDatabase");
            //Setting optionbuilder for dbcontext
            var optionBuilder = new DbContextOptionsBuilder<DotNetCorePracticeDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new DotNetCorePracticeDbContext(optionBuilder.Options);
        }
    }
}

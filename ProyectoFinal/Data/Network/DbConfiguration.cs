using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Network
{
    public class DbConfiguration
    {
        public static void ConfigureAzureSQL(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null
                );

                sqlOptions.CommandTimeout(60);
                sqlOptions.MigrationsAssembly("ERP.Backend.Data");
            });

            options.EnableSensitiveDataLogging(false);
            options.EnableDetailedErrors(false);
        }
    }
}
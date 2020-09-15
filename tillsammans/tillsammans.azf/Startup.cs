using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tillsammans.Auth;

[assembly: FunctionsStartup(typeof(tillsammans.Startup))]

namespace tillsammans
{
    public class Startup : FunctionsStartup
    {
        public static IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ITokenService, TokenService>();
        }
    }

}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Binder;
using Omt.Application;
using Omt.Domain;
using Omt.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omt.Test
{
    public class IntegrationTestFixture
    {
        public const string CFG_FILE = "appsettings.Test.json";
        public ServiceProvider ServiceProvider { get; private set; }

        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<RequestHelper>();
            serviceCollection.AddTransient<IInterestApplication, InterestApplication>();
            serviceCollection.AddOptions();
            serviceCollection.AddHttpClient();

            // injeta IOptions
            serviceCollection.Configure<AppConfig>(InitConfiguration().GetSection("AppConfig"));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public static IConfiguration InitConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(CFG_FILE)
                .Build();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        public IntegrationTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<RequestHelper>();
            serviceCollection.AddTransient<IInterestApplication, InterestApplication>();
            serviceCollection.AddOptions();
            serviceCollection.AddHttpClient();
            //serviceCollection.Configure<AppConfig>(ConfigurationBinder.Bind(null, null);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}

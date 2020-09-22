using System;
using Omt.Domain;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Omt.Infra.CrossCuting
{
    public class Utils
    {
        private readonly IConfiguration Configuration;

        public Utils(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AppConfig BindConfig() {
            var appConfig = new AppConfig();
            Configuration.GetSection(appConfig.Key).Bind(appConfig);
            return appConfig;
        }
    }
}

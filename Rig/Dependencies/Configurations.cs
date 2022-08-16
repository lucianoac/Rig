using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rig.Dependencies
{
    public static class Configurations
    {
        private static readonly Lazy<IConfigurationRoot>
       _configurationRoot = new Lazy<IConfigurationRoot>(() => new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build());

        private static IConfigurationRoot Configuration => _configurationRoot.Value;

        public static string DefaultConnectionString => Configuration.GetConnectionString("DefaultConnection");

        public static bool EnableEfConsoleLog => Configuration.GetValue("EnableEfConsoleLog", false);

    }
}

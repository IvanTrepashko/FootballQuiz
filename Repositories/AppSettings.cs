using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace Repositories
{
    internal static class AppSettings
    {
        public static IConfigurationRoot Configuration { get; set; }

        static AppSettings()
        {
            Debug.WriteLine("Constr called");
            Debug.WriteLine(Directory.GetCurrentDirectory());
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}

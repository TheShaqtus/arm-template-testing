using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Volleyball.Integration.Tests
{
    [TestClass]
    public static class Initialize
    {
        public static IConfiguration Configuration;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var config = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json",
                optional: false,
                reloadOnChange: false);
            Configuration = config.Build();
        }
    }
}
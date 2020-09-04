using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Volleyball.Integration.Tests
{
    [TestClass]
    public static class Initialize
    {
        public static string BaseUrl;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            BaseUrl = context.Properties["apiUrl"]?.ToString();
        }
    }
}
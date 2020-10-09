using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Volleyball.DataAccess;

namespace Volleyball.Integration.Tests
{
    [TestClass]
    public static class Initialize
    {
        public static string BaseUrl;
        public static string ConnectionString;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            BaseUrl = context.Properties["apiUrl"]?.ToString();
            ConnectionString = context.Properties["connectionString"]?.ToString();

            var dbContextOptions = new DbContextOptionsBuilder<VolleyballContext>();
            dbContextOptions.UseSqlServer(ConnectionString);
            var dbContext = new VolleyballContext(dbContextOptions.Options);

            dbContext.Database.Migrate();
        }
    }
}
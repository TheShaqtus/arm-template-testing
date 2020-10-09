using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Volleyball.DataAccess;

namespace Volleyball.Integration.Tests
{
    public class TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var dbContextOptions = new DbContextOptionsBuilder<VolleyballContext>();
            dbContextOptions.UseSqlServer(Initialize.ConnectionString);
            var dbContext = new VolleyballContext(dbContextOptions.Options);

            var clearSqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/ClearDB.sql");
            dbContext.Database.ExecuteSqlRaw(File.ReadAllText(clearSqlFile));

            var createSqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sql/CreateTestData.sql");
            dbContext.Database.ExecuteSqlRaw(File.ReadAllText(createSqlFile));
        }
    }
}
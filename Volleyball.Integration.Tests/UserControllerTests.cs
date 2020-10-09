using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Volleyball.Models;

namespace Volleyball.Integration.Tests
{
    [UseReporter(typeof(DiffReporter), typeof(MsTestReporter))]
    [UseApprovalSubdirectory("Approvals")]
    [TestClass]
    public class UserControllerTests : TestBase
    {
        [TestMethod]
        public async Task Get()
        {
            // Arrange
            var client = new HttpClient();

            // Act
            var result = await client.GetAsync($"{Initialize.BaseUrl}/users")
                .ConfigureAwait(false);
            var users = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Assert
            Approvals.VerifyJson(users);
        }

        [TestMethod]
        public async Task Post()
        {
            // Arrange
            var newUser = new CreateUserModel {FirstName = "Test", LastName = "User"};

            var client = new HttpClient();
            
            var content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync(
                    $"{Initialize.BaseUrl}/users",
                    content)
                .ConfigureAwait(false);

            Assert.IsTrue(result.IsSuccessStatusCode);

            var getResults = await client
                .GetAsync($"{Initialize.BaseUrl}/users")
                .ConfigureAwait(false);

            var users = await getResults.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Assert
            Approvals.VerifyJson(users);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Volleyball.Models;

namespace Volleyball.Integration.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task Post()
        {
            var newUser = new CreateUserModel {FirstName = "Test", LastName = "User"};

            var client = new HttpClient();
            
            var content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(
                    $"{Initialize.Configuration["BaseUrl"]}/users",
                    content)
                .ConfigureAwait(false);

            Assert.IsTrue(result.IsSuccessStatusCode);

            var getResults = await client
                .GetAsync($"{Initialize.Configuration["BaseUrl"]}/users")
                .ConfigureAwait(false);

            var users = JsonConvert.DeserializeObject<List<UserModel>>(
                await getResults.Content.ReadAsStringAsync().ConfigureAwait(false));

            Assert.AreEqual(1, users.Count);
        }
    }
}

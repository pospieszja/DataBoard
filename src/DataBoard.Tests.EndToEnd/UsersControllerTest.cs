using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DataBoard.Infrastructure.Commands.Users;
using DataBoard.Infrastructure.DTO;
using DataBoard.Tests.EndToEnd.Helpers;
using DataBoard.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace DataBoard.Tests.EndToEnd
{
    public class UsersControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@a.pl";

            var response = await _client.GetAsync($"/users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            Assert.Equal(email, user.Email);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task given_valid_email_user_should_not_exist()
        {
            var email = "not@exist.com";

            var response = await _client.GetAsync($"/users/{email}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var command = new CreateUser();
            command.Email = "user999@mail.com";
            command.Password = "secret";

            var payload = new JsonContent(command);
            var response = await _client.PostAsync("users/", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(response.Headers.Location.ToString(), $"/users/{command.Email}");
        }
    }
}

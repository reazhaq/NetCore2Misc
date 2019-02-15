using System.Net;
using System.Net.Http;
using NetCoreApiOne;
using Xunit;

namespace NetCoreApiOneTests.Controllers
{
    public class BlahBlahControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public BlahBlahControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public void BlahTest()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/BlahBlah");

            var response = _client.SendAsync(request).Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
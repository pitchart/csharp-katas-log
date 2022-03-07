using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Approval.Shared.ReadModels;
using FluentAssertions;
using Newtonsoft.Json;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Integration
{
    [UsesVerify]
    public class DynamicPersonControllerTests : AppFactory
    {
        private HttpClient _httpClient;
        public DynamicPersonControllerTests()
        {
            _httpClient = CreateClient();
        }
        

        [Fact]
        public Task Should_return_dynamic_person()
        {
            var result = _httpClient.GetAsync("/dynamicPerson").Result;
            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            var montana =
                JsonConvert.DeserializeObject<DynamicPerson>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            return Verify(montana);

        }
    }
}

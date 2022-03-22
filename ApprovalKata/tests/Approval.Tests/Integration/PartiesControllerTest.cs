using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;

namespace Approval.Tests.Integration
{
    [UsesVerify]
    public class PartiesControllerTest : IClassFixture<AppFactory>
    {
        private readonly HttpClient Client;

        public PartiesControllerTest(AppFactory factory) : base()
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Retrieve_Capone_And_Mesrine_With_Verify()
             => await Client.GetAsync("/parties")
                 .Verify(_ => _.DontScrubDateTimes());
    }
}

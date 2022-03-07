using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using Approval.Web;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;

namespace Approval.Tests.Integration
{
    [UsesVerify]
    public class IndividualPartiesControllerTests : AppFactory
    {
        private HttpClient _httpClient;
        public IndividualPartiesControllerTests()
        {
            _httpClient = CreateClient();
        }

        [Fact]
        public async Task Should_Map_PersonAccounts_To_IndividualParties()
        {
            //Arrange
            var alCapOne = DataBuilder.AlCapone();
            var mesrine = DataBuilder.Mesrine();

            //Act
            var result = await _httpClient.GetAsync("/individualParties");

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var individualParties =
                JsonConvert.DeserializeObject<IndividualParty[]>(await result.Content.ReadAsStringAsync());

            AssertAlCapOne(individualParties[0], alCapOne);
            AssertMesrine(individualParties[1], mesrine);
        }

        [Fact]
        public Task Should_Map_PersonAccounts_To_IndividualParties_WithVerify()
        {
            //Act
            var result =  _httpClient.GetAsync("/individualParties").Result;

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var individualParties =
                JsonConvert.DeserializeObject<IndividualParty[]>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            return Verify(individualParties).ModifySerialization(opt => opt.DontScrubDateTimes());
        }

        private static void AssertAlCapOne(IndividualParty individualParty, PersonAccount personAccount)
        {
            individualParty.BirthCity.Should().Be(personAccount.CityOfBirth__pc);
            individualParty.BirthDate.Should().Be(25.January(1899));
            individualParty.FirstName.Should().Be(personAccount.FirstName);
            individualParty.LastName.Should().Be(personAccount.LastName);
            individualParty.MiddleName.Should().Be(personAccount.MiddleName);
            individualParty.PepMep.Should().Be(false);
            individualParty.Title.Should().Be(personAccount.Salutation);
            individualParty.Documents.First().DocumentType.Should().Be(personAccount.LegalDocumentName1__c);
            individualParty.Documents.First().ExpirationDate.Should().Be(5.January(2000));
            individualParty.Documents.First().Number.Should().Be(personAccount.LegalDocumentNumber1__c);
            individualParty.Gender.Should().Be(Gender.Male);
        }

        private static void AssertMesrine(IndividualParty individualParty, PersonAccount personAccount)
        {
            individualParty.BirthCity.Should().Be(personAccount.CityOfBirth__pc);
            individualParty.BirthDate.Should().Be(28.December(1936));
            individualParty.FirstName.Should().Be(personAccount.FirstName);
            individualParty.LastName.Should().Be(personAccount.LastName);
            individualParty.MiddleName.Should().Be(personAccount.MiddleName);
            individualParty.PepMep.Should().Be(true);
            individualParty.Title.Should().Be(personAccount.Salutation);
            individualParty.Documents.First().DocumentType.Should().Be(personAccount.LegalDocumentName1__c);
            individualParty.Documents.First().ExpirationDate.Should().Be(30.September(2020));
            individualParty.Documents.First().Number.Should().Be(personAccount.LegalDocumentNumber1__c);
            individualParty.Documents.Last().DocumentType.Should().Be(personAccount.LegalDocumentName2__c);
            individualParty.Documents.Last().ExpirationDate.Should().Be(23.December(1990));
            individualParty.Documents.Last().Number.Should().Be(personAccount.LegalDocumentNumber2__c);
            individualParty.Gender.Should().Be(Gender.Male);
        }
    }
}

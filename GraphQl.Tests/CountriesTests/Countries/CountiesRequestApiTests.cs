using FluentAssertions;
using FluentAssertions.Execution;
using GraphQl.Client.Builders;
using GraphQl.Client.Client;
using GraphQl.Countries.Client.Models.Response;
using NUnit.Framework;
using System.Net;

namespace GraphQl.Tests.CountriesTests.Countries
{
    public class CountiesRequestApiTests : CountriesTestBase
    {
        [Test]
        public void GetCountries_WithExistCode_ReturnSpecifiedFields_ShouldBeReturned()
        {
            var arguments = new Dictionary<string, string>
            {
                { "code", "UA" }
            };

            string query = new GraphQLQueryBuilder()
                .AddOperation("Query", "country", arguments)
                .AddField("name")
                .AddField("native")
                .AddField("capital")
                .AddField("emoji")
                .AddField("currency")
                .AddNestedField("languages", (languagesQuery) =>
                {
                    languagesQuery
                        .AddField("code")
                        .AddField("name");
                })
                .Build();

            //Act
            var response = new GraphQlClient(BaseUrl!)
                .AddBody(query)
                .SendQueryRequest();

            var responsModel = response.DeserializeResponse<CountryDataResponseApiModel>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Data dataProperty = responsModel!.Data!;
            dataProperty.Should().NotBeNull();
            CountryApiModel countryProperty = dataProperty!.Country!;
            countryProperty.Should().NotBeNull();

            using (new AssertionScope())
            {
                countryProperty.Name.Should().Be("Ukraine");
                countryProperty.Native.Should().Be("Україна");
                countryProperty.Capital.Should().Be("Kyiv");
                countryProperty.Emoji.Should().Be("🇺🇦");
                countryProperty.Currency.Should().Be("UAH");
                countryProperty.Languages
                    .Should()
                    .BeEquivalentTo(new List<LanguageApiModel>
                    {
                        new LanguageApiModel
                        {
                            Code = "uk",
                            Name = "Ukrainian",
                            Native = null,
                            Rtl = null
                        }
                    });
                countryProperty.States.Should().BeNullOrEmpty();
                countryProperty.Continent.Should().BeNull();
            }
        }

        [Test]
        public void GetCountries_WithCode_DoesNotExist_OkAndEmptyDataReturned()
        {
            var arguments = new Dictionary<string, string>
            {
                { "code", "AA" }
            };

            string query = new GraphQLQueryBuilder()
                .AddOperation("Query", "country", arguments)
                .AddField("name")
                .Build();

            //Act
            var response = new GraphQlClient(BaseUrl!)
                .AddBody(query)
                .SendQueryRequest();

            var responsModel = response.DeserializeResponse<CountryDataResponseApiModel>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Data dataProperty = responsModel!.Data!;
            dataProperty.Should().NotBeNull();
            CountryApiModel countryProperty = dataProperty!.Country!;
            countryProperty.Should().BeNull();
        }
    }
}

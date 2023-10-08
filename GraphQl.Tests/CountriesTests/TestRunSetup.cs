using GraphQl.Client.Configuration;
using NUnit.Framework;

namespace GraphQl.Tests.CountriesTests
{
    [SetUpFixture]
    public class TestRunSetup
    {
        public static string? CountriesBaseUrl;

        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            CountriesBaseUrl = RunSettingsManager.GetNotNullableStringParameter("countriesApiBaseUrl");
        }
    }
}

using GraphQl.Client.TestManagers;
using NLog;
using NUnit.Framework;

namespace GraphQl.Tests.CountriesTests
{
    [SetUpFixture]
    public class TestRunSetup
    {
        public static string? CountriesBaseUrl { get; private set; }

        public static Logger? Log { get; private set; }


        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            CountriesBaseUrl = RunSettingsManager.GetNotNullableStringParameter("countriesApiBaseUrl");
            Log = new NLogManager().Log;
        }
    }
}

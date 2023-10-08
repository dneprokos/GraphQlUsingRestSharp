using NUnit.Framework;

namespace GraphQl.Tests.CountriesTests
{
    [TestFixture]
    public class CountriesTestBase
    {
        public string? BaseUrl;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            BaseUrl = TestRunSetup.CountriesBaseUrl;
        }
    }
}

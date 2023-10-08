using NLog;
using NUnit.Framework;

namespace GraphQl.Tests.CountriesTests
{
    [TestFixture]
    public class CountriesTestBase
    {
        protected static string? BaseUrl { get; private set; }
        protected static Logger? Log { get; private set; }

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            BaseUrl = TestRunSetup.CountriesBaseUrl;
            Log = TestRunSetup.Log;
        }
    }
}

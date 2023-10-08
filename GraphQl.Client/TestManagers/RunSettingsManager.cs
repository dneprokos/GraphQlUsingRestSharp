using FluentAssertions;
using NUnit.Framework;

namespace GraphQl.Client.TestManagers
{
    public static class RunSettingsManager
    {
        /// <summary>
        /// Reads TestRunParameter and verifies if value is not null or empty before returning it
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string? GetNotNullableStringParameter(string key)
        {
            var value = TestContext.Parameters[key];
            value.Should().NotBeNullOrEmpty($"Specified key '{key}' was not found in .runsettings");

            return value;
        }

        /// <summary>
        /// Reads TestRunParameter and returns any found value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string? GetNullableStringParameter(string key)
            => TestContext.Parameters[key];
    }
}

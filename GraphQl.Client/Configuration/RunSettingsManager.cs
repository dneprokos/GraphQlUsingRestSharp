using FluentAssertions;
using NUnit.Framework;

namespace GraphQl.Client.Configuration
{
    public static class RunSettingsManager
    {
        public static string? GetNotNullableStringParameter(string key)
        {
            var value = TestContext.Parameters[key];
            value.Should().NotBeNullOrEmpty($"Specified key '{key}' was not found in .runsettings");

            return value;
        }
    }
}

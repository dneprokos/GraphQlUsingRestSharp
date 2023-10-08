using NLog;

namespace GraphQl.Client.TestManagers
{
    public class NLogManager
    {
        public Logger? Log { get; private set; }

        public NLogManager()
        {
            //Set log level based on .runsettings configuration
            string logLevel = RunSettingsManager.GetNullableStringParameter("logLevel")!;
            if (!string.IsNullOrEmpty(logLevel))
            {
                LogManager.Configuration.Variables["logLevel"] = logLevel;
                LogManager.ReconfigExistingLoggers();
            };

            Log = LogManager.GetCurrentClassLogger();
        }
    }
}

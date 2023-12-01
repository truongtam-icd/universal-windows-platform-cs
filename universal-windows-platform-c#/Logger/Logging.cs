using Serilog;
using System.IO;
using System.ServiceModel.Channels;
using Windows.Storage;

namespace Logger
{
    public class Logging
    {
        const string fileLog = "logs\\log.txt";

        public static string LogPath => Path.Combine(ApplicationData.Current.LocalFolder.Path, fileLog);

        public static void Info(string message)
        {
            var logFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileLog);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information(message);
            Log.CloseAndFlush();
        }

        public static void Error(string message)
        {
            var logFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileLog);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Error(message);
            Log.CloseAndFlush();
        }
    }
}

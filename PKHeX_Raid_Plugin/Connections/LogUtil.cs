using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using System.Text;

namespace PKHeX_Raid_Plugin;

/// <summary>
/// Logic wrapper to handle logging (via NLog).
/// </summary>
public static class LogUtil
{
    static LogUtil()
    {
        if (!LogConfig.LoggingEnabled)
            return;

        var config = new LoggingConfiguration();
        Directory.CreateDirectory("logs");
        var WorkingDirectory = Path.GetDirectoryName(Environment.ProcessPath)!;
        var logfile = new FileTarget("logfile")
        {
            FileName = Path.Combine(WorkingDirectory, "logs", "PluginLog.txt"),

            ArchiveEvery = FileArchivePeriod.Day,
            ArchiveSuffixFormat = "{1:yyyy-MM-dd}",
            ArchiveFileName = Path.Combine(WorkingDirectory, "logs", "PluginLog.{#}.txt"),
            ArchiveAboveSize = 104857600, // 100MB (never)
            MaxArchiveFiles = LogConfig.MaxArchiveFiles,
            Encoding = Encoding.Unicode,
            WriteBom = true,
        };
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        LogManager.Configuration = config;
    }

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    public static void LogText(string message) => Logger.Log(LogLevel.Info, message);

    public static DateTime LastLogged { get; private set; } = DateTime.Now;

    public static void LogError(string message, string identity)
    {
        Logger.Log(LogLevel.Error, $"{identity} {message}");
    }

    public static void LogInfo(string message, string identity)
    {
        Logger.Log(LogLevel.Info, $"{identity} {message}");
    }

    public static void LogSafe(Exception exception, string identity)
    {
        Logger.Log(LogLevel.Error, $"Exception from {identity}:");
        Logger.Log(LogLevel.Error, exception);

        var err = exception.InnerException;
        while (err is not null)
        {
            Logger.Log(LogLevel.Error, err);
            err = err.InnerException;
        }
    }
}
public static class LogConfig
{
    public static int MaxArchiveFiles { get; set; } = 14; // 2 weeks
    public static bool LoggingEnabled { get; set; } = true;
}

﻿using System;
using System.Threading.Tasks;
using Discord;

namespace SnapShot_Discord_Bot
{
    public class LoggingService
    {
    // Logging handler. This can be re-used by addons
    // that ask for a Func<LogMessage, Task>.
    public static Task Log(LogMessage message)
    {
    switch (message.Severity)
        {
        case LogSeverity.Critical:
        case LogSeverity.Error:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        case LogSeverity.Warning:
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        case LogSeverity.Info:
            Console.ForegroundColor = ConsoleColor.White;
            break;
        case LogSeverity.Verbose:
        case LogSeverity.Debug:
            Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
        }
        Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message} {message.Exception}");
        Console.ResetColor();
        // If you get an error saying 'CompletedTask' doesn't exist,
        // your project is targeting .NET 4.5.2 or lower. You'll need
        // to adjust your project's target framework to 4.6 or higher
        // (instructions for this are easily Googled).
        // If you *need* to run on .NET 4.5 for compat/other reasons,
        // the alternative is to 'return Task.Delay(0);' instead.
        return Task.CompletedTask;
        }
    }
}

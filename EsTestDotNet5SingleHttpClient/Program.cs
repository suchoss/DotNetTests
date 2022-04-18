using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Common;
using Serilog;

namespace DotNetTests
{
    public static class Program
    {
        public static void Main()
        {
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("testlog.txt");
            Log.Logger = loggerConfig.CreateLogger();

            HttpClient client = new HttpClient();
            client.BaseAddress = Settings.ElasticUris().First();

            var icoList = Settings.IcoList();
            var timerList = new List<MyTimer>();

            while (true)
            {
                Console.WriteLine(
                    "About 40 timers will fail after few minutes - but subjectively it takes a bit longer than in .NET 6 (on my PC setup)");
                Console.WriteLine("A - add timer; S - stop last timer; Q - quit");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Adding timer");
                        var ico = icoList[timerList.Count % icoList.Count];
                        timerList.Add(new MyTimer(ico, client, Log.Logger));
                        //timerList.Add(new MyTimer(ico, client2, Log.Logger));
                        Console.WriteLine($"currently running {timerList.Count} timers");
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Removing timer");
                        if (timerList.Count > 0)
                        {
                            int last = timerList.Count - 1;
                            timerList[last].ClearTimer();
                            timerList.RemoveAt(last);
                        }

                        Console.WriteLine($"currently running {timerList.Count} timers");
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine("Goodbye");
                        return;
                }
            }
        }
    }
}
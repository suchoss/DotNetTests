using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Common;
using Microsoft.Extensions.DependencyInjection;
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


            var uri = Settings.ElasticUris().First();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient("basic", c => c.BaseAddress = uri);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();


            var icoList = Settings.IcoList();
            var timerList = new List<MyTimer>();

            while (true)
            {
                Console.WriteLine("Strangely threads will never start raising even if I had over 500 timers (on my PC setup)");
                Console.WriteLine("But it can only send about 40 requests per second when on over 100 timers");
                Console.WriteLine("Are some requests lost?");
                
                Console.WriteLine("A - add timer; S - stop last timer; Q - quit");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Adding timer");
                        var ico = icoList[timerList.Count % icoList.Count];
                        timerList.Add(new MyTimer(ico, httpClientFactory, Log.Logger));
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
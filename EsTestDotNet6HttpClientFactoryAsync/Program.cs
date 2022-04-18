// See https://aka.ms/new-console-template for more information

using Common;
using DotNetTests;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


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
    Console.WriteLine("About 300 timers and it still works without problems");
    Console.WriteLine("It can go 190 requests/s. 3 times more than synchronous.");
    Console.WriteLine("");
    
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
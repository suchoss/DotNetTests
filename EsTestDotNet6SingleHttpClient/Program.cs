// See https://aka.ms/new-console-template for more information

using Common;
using DotNetTests;
using Serilog;


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
    Console.WriteLine("About 40 timers will fail after few minutes (on my PC setup)");
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
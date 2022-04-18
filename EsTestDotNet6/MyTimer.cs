using Nest;
using Serilog;

namespace DotNetTests;

public class MyTimer
{
    private System.Timers.Timer _timer;
    private string _ico;
    private ElasticClient _client;
    private ILogger _logger;

    public MyTimer(string ico, ElasticClient client, ILogger logger)
    {
        _ico = ico;
        _client = client;
        _logger = logger;

        _timer = new System.Timers.Timer();
        _timer.Interval = 1000; // once per sec
        _timer.Elapsed += TimerElapsed;
        _timer.Start();
    }

    public void ClearTimer()
    {
        _timer.Elapsed -= TimerElapsed;
        _timer.Stop();
        _timer.Dispose();
    }

    private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        try
        {
            var data = _client.Get<MyData>(_ico);

            if (data.IsValid && data.Found)
            {
                _logger.Debug("Found {ico}", data.Source.Ico);
            }
            else
            {
                _logger.Warning("Not found {ico}", _ico);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error for {ico}", _ico);
        }

    }
}
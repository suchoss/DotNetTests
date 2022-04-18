using Serilog;

namespace DotNetTests;

public class MyTimer
{
    private System.Timers.Timer _timer;
    private string _ico;
    private HttpClient _client;
    private ILogger _logger;

    public MyTimer(string ico, HttpClient client, ILogger logger)
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
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/kindex/_doc/{_ico}");
            var data = _client.Send(httpRequest);

            if (data.IsSuccessStatusCode)
            {
                _logger.Debug("Found {ico}", _ico);
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
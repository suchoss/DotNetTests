using Serilog;

namespace DotNetTests;

public class MyTimer
{
    private System.Timers.Timer _timer;
    private string _ico;
    private IHttpClientFactory _httpClientFactory;
    private ILogger _logger;

    public MyTimer(string ico, IHttpClientFactory httpClientFactory, ILogger logger)
    {
        _ico = ico;
        _httpClientFactory = httpClientFactory;
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
            var httpclient = _httpClientFactory.CreateClient("basic");
            
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/kindex/_doc/{_ico}");
            var data = httpclient.Send(httpRequest);
            
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
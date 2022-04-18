using Serilog;

namespace DotNetTests;

public class MyTimer
{
    private string _ico;
    private IHttpClientFactory _httpClientFactory;
    private ILogger _logger;
    private Task _timer;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public MyTimer(string ico, IHttpClientFactory httpClientFactory, ILogger logger)
    {
        _ico = ico;
        _httpClientFactory = httpClientFactory;
        _logger = logger;

        _cancellationTokenSource = new CancellationTokenSource();
        _timer = RunInBackground();
    }

    public void ClearTimer()
    {
        _cancellationTokenSource.Cancel();
    }

    private async Task RunInBackground()
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        while (await periodicTimer.WaitForNextTickAsync(_cancellationTokenSource.Token))
        {
            if (_cancellationTokenSource.Token.IsCancellationRequested)
                return;

            try
            {
                var httpclient = _httpClientFactory.CreateClient("basic");

                using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/kindex/_doc/{_ico}");
                var data = await httpclient.SendAsync(httpRequest, _cancellationTokenSource.Token);

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
}
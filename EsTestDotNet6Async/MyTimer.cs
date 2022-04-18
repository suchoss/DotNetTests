using Nest;
using Serilog;

namespace DotNetTests;

public class MyTimer
{
    private Task _timer;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private string _ico;
    private ElasticClient _client;
    private ILogger _logger;

    public MyTimer(string ico, ElasticClient client, ILogger logger)
    {
        _ico = ico;
        _client = client;
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
                var data = await _client.GetAsync<MyData>(_ico, ct: _cancellationTokenSource.Token);

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

}
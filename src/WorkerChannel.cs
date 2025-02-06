using System.Threading.Channels;

namespace Channels;

public record WorkerChannelRequestModel(string Name, string Description);

public class WorkerChannel : BackgroundService
{
  private readonly Channel<WorkerChannelRequestModel> _channel;

  public WorkerChannel(Channel<WorkerChannelRequestModel> channel)
  {
    _channel = channel;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (await _channel.Reader.WaitToReadAsync(stoppingToken))
    {
      var request = await _channel.Reader.ReadAsync(stoppingToken);

      Console.WriteLine($"Name: {request.Name}, Description: {request.Description}");
    }
  }
}

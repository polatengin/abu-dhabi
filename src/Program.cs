using System.Threading.Channels;
using Channels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<WorkerChannel>();

builder.Services.AddSingleton(Channel.CreateUnbounded<WorkerChannelRequestModel>(new UnboundedChannelOptions()
{
  SingleReader = true,
  AllowSynchronousContinuations = false
}));

var app = builder.Build();

app.MapGet("/", async (Channel<WorkerChannelRequestModel> channel) =>
{
  await channel.Writer.WriteAsync(new WorkerChannelRequestModel("Hello", "World"));

  return Results.Ok();
});

await app.RunAsync();

# dotnet 8 Web Api project that uses Channels to invoke BackgroundService functions

This repository contains a _.NET 8.0_ _Web Api_ project.

```shell
dotnet new web
```

The project includes a _background service_ that processes requests using a _channel_. Here is a brief overview of the key components:

`Background Service`: The [WorkerChannel](./src/WorkerChannel.cs) class reads and processes requests from a _channel_.

`Web Application`: The [Program.cs](./src/Program.cs) file sets up the web application, registers the background service, and defines an endpoint that writes requests to the channel.

When you run the application and send a GET request to the root endpoint (`/`), it writes a request to the channel, which is then processed by the background service.

```shell
dotnet run
```

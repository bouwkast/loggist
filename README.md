# loggist

A .NET library logging framework that ties into your project and provides integration with [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/). Similar to what [LibLog](https://github.com/damianh/LibLog) was.

## How loggist Works

> Note: loggist has a dependency on the `Microsoft.Extensions.Logging.Abstractions`, this means your library will also require this dependency as will consumers of your library. If this is undesirable, it is not recommended to use loggist and to instead provide a custom logging abstraction within your library.

When [loggist](https://www.nuget.org/packages/loggist/) is installed into your library it does a transform on two source files and places them within a `Logging` namespace in your project's namespace: `LoggingConfiguration.cs` and `LogProvider.cs`.

The `LoggingConfiguration` class provides a static property `LoggingConfiguration.LoggerFactory` - this is where consumers will set their desired `ILoggerFactory` that will be used by your library.

The `LogProvider` class is internal scope and provides a static function to get an `ILogger` scoped to the class specified:

```cs
private ILogger<Foo> _logger = Logging.LogProvider<Foo>.GetCurrentClassLogger();
```

The `LogProvider` handles instances when no `LoggerFactory` is set and will use the `NullLogger` instance.

## Serilog Example

Users can easily add logging to support to your library when loggist is installed. For Serilog, the `Serilog.Extensions.Logging` NuGet will need to be installed by end users. Then the `LoggingConfiguration.LoggerFactory` needs to be set after configuring Serilog:

```cs
Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(new CompactJsonFormatter())
            .CreateLogger();

// there are other ways of doing this by creating a LoggerFactory and then calling AddProvider to it
loggist.Example.Library.Logging.LoggingConfiguration.LoggerFactory = new Microsoft.Extensions.Logging.LoggerFactory().AddSerilog();
```
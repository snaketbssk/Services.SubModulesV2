using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using System.Text.Json;
using System;
using Services.SubModules.LogicLayers.Sinks.HttpClients.Entities;
using Microsoft.Extensions.Configuration;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder UseSerilog<T>(this IHostBuilder hostBuilder)
        {

            hostBuilder.UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var nameAssembly = typeof(T).Assembly.GetName().Name;

                var root = SerilogConfiguration<SerilogRoot>.Instance.Root;
                var nameFile = string.Format(root.File.Path, nameAssembly);
                var path = Path.Combine(baseDirectory, nameFile);

                loggerConfiguration
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: (LogEventLevel)root.Console.LogEventLevel,
                                     theme: AnsiConsoleTheme.Code)
                    .WriteTo.File(path: path,
                                  restrictedToMinimumLevel: (LogEventLevel)root.File.LogEventLevel)
                    .WriteTo.Seq(serverUrl: root.Seq.ServerUrl,
                                 apiKey: root.Seq.ApiKey,
                                 restrictedToMinimumLevel: (LogEventLevel)root.Seq.LogEventLevel);
                if (root.Logger.IsEnable)
                {
                    loggerConfiguration
                        .WriteTo.Http(requestUri: root.Logger.ServerUrl,
                                      queueLimitBytes: null,
                                      httpClient: new JsonHttpClient(root.Logger.ApiKey),
                                      restrictedToMinimumLevel: (LogEventLevel)root.Logger.LogEventLevel);
                }
            });

            using (var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger())
            {
                var grpcRoot = JsonSerializer.Serialize(GrpcConfiguration<GrpcRoot>.Instance.Root,
                                                    new JsonSerializerOptions { WriteIndented = true });
                log.Information($"{nameof(grpcRoot)} {grpcRoot}");

                var redisRoot = JsonSerializer.Serialize(RedisConfiguration<RedisRoot>.Instance.Root,
                                                    new JsonSerializerOptions { WriteIndented = true });
                log.Information($"{nameof(redisRoot)} {redisRoot}");
            }

            return hostBuilder;
        }
    }
}

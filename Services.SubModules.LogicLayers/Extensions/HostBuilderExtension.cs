using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Sinks.HttpClients.Entities;
using Services.SubModules.LogicLayers.Sinks.TextFormatters.Entities;
using System.Text.Json;

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

                var envirement = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var indexFormat = $"{nameAssembly.ToLower()}-{envirement.ToLower().Replace('.', '-')}-{DateTime.UtcNow:yyyy-MM}";

                loggerConfiguration
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: (LogEventLevel)root.Console.LogEventLevel,
                                     theme: AnsiConsoleTheme.Code)
                    .WriteTo.File(path: path,
                                  restrictedToMinimumLevel: (LogEventLevel)root.File.LogEventLevel)
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://93.114.133.241:9200")) 
                    {
                        IndexFormat = indexFormat,
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
                        MinimumLogEventLevel = (LogEventLevel)root.ElasticSearch.LogEventLevel
                    });
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

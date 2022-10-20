using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;

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
                    .WriteTo.Console(restrictedToMinimumLevel: (LogEventLevel)root.Console.LogEventLevel,
                                     theme: AnsiConsoleTheme.Code)
                    .WriteTo.File(path: path,
                                  restrictedToMinimumLevel: (LogEventLevel)root.File.LogEventLevel)
                    .WriteTo.Seq(serverUrl: root.Seq.ServerUrl,
                                 apiKey: root.Seq.ApiKey,
                                 restrictedToMinimumLevel: (LogEventLevel)root.Seq.LogEventLevel);
            });

            return hostBuilder;
        }
    }
}

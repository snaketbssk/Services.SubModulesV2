using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Services.SubModules.Configurations.Constants;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder SetEnvironments<T>(this IHostBuilder hostBuilder)
        {
            var keyAssembly = $"{ConfigurationConstant.ASPNETCORE_ENVIRONMENT}{nameof(AspNetCoreEnvironmentRoot.ASSEMBLY)}";
            var valueAssembly = typeof(T).Assembly.GetName().Name;
            Environment.SetEnvironmentVariable(keyAssembly, valueAssembly);

            var keySession = $"{ConfigurationConstant.ASPNETCORE_ENVIRONMENT}{nameof(AspNetCoreEnvironmentRoot.SESSION)}";
            var valueSession = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(keySession, valueSession);

            return hostBuilder;
        }

        public static IHostBuilder UseSerilog(this IHostBuilder hostBuilder)
        {
            var rootAspNetCore = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();
            var rootSerilog = SerilogEnvironmentConfiguration<SerilogEnvironmentRoot>.Instance.GetRoot();

            hostBuilder.UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                
                var nameFile = string.Format(rootSerilog.FILE_PATH, rootAspNetCore.ASSEMBLY);
                var path = Path.Combine(baseDirectory, nameFile);

                loggerConfiguration
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: (LogEventLevel)rootSerilog.CONSOLE_LEVEL,
                                     theme: AnsiConsoleTheme.Code)
                    .WriteTo.File(path: path,
                                  restrictedToMinimumLevel: (LogEventLevel)rootSerilog.FILE_LEVEL)
                    .WriteTo.Seq(serverUrl: rootSerilog.SEQ_HOST,
                                 apiKey: rootSerilog.SEQ_API_KEY,
                                 restrictedToMinimumLevel: (LogEventLevel)rootSerilog.SEQ_LEVEL);
            });

            return hostBuilder;
        }
    }
}

using dotenv.net;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Services.SubModules.Configurations.Constants;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using System.Collections;
using System.Text.RegularExpressions;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder SetEnvironments<T>(this IHostBuilder hostBuilder, string nameService)
        {
            var envFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
            DotEnv.Fluent().WithEnvFiles(envFile).Load();

            var keyNameService = $"{ConfigurationConstant.SERVICE_ENVIRONMENT}NAME";
            Environment.SetEnvironmentVariable(keyNameService, $"{nameService}_");

            var keyAssembly = $"{ConfigurationConstant.ASPNETCORE_ENVIRONMENT}{nameof(AspNetCoreEnvironmentRoot.ASSEMBLY)}";
            var valueAssembly = typeof(T).Assembly.GetName().Name;
            Environment.SetEnvironmentVariable(keyAssembly, valueAssembly);

            var keySession = $"{ConfigurationConstant.ASPNETCORE_ENVIRONMENT}{nameof(AspNetCoreEnvironmentRoot.SESSION)}";
            var valueSession = Guid.NewGuid().ToString();
            Environment.SetEnvironmentVariable(keySession, valueSession);

            var pattern = @"\${\w+}";
            foreach (DictionaryEntry environment in Environment.GetEnvironmentVariables())
            {
                if (environment.Value is null)
                    continue;

                var key = environment.Key.ToString();
                var value = environment.Value.ToString();
                var matches = Regex.Matches(value, pattern);
                foreach (Match match in matches)
                {
                    var clearMatch = match.Value.Replace("$", string.Empty)
                                                .Replace("{", string.Empty)
                                                .Replace("}", string.Empty);
                    var replace = Environment.GetEnvironmentVariable(clearMatch);

                    if (string.IsNullOrWhiteSpace(replace))
                        continue;

                    value = value.Replace(match.Value, replace);
                }

                if (!environment.Value.Equals(value))
                    Environment.SetEnvironmentVariable(key, value);
            }

            return hostBuilder;
        }

        public static IHostBuilder UseServiceSerilog(this IHostBuilder hostBuilder)
        {
            var rootAspNetCore = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();
            var rootSerilog = SerilogEnvironmentConfiguration<SerilogEnvironmentRoot>.Instance.GetRoot();
            ArgumentNullException.ThrowIfNull(rootAspNetCore, nameof(rootAspNetCore));

            ArgumentNullException.ThrowIfNull(rootSerilog, nameof(rootSerilog));
            ArgumentNullException.ThrowIfNull(rootSerilog.FILE_PATH, nameof(rootSerilog.FILE_PATH));
            ArgumentNullException.ThrowIfNull(rootSerilog.CONSOLE_LEVEL, nameof(rootSerilog.CONSOLE_LEVEL));
            ArgumentNullException.ThrowIfNull(rootSerilog.FILE_LEVEL, nameof(rootSerilog.FILE_LEVEL));
            ArgumentNullException.ThrowIfNull(rootSerilog.SEQ_HOST, nameof(rootSerilog.SEQ_HOST));
            ArgumentNullException.ThrowIfNull(rootSerilog.SEQ_LEVEL, nameof(rootSerilog.SEQ_LEVEL));

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

            using (var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger())
            {
                WriteToConsole(logger, rootAspNetCore);
            }

            return hostBuilder;
        }

        private static void WriteToConsole(Logger logger, object entity)
        {
            var entityType = entity.GetType();
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                logger.Information($"{property.Name}: {value}");
            }
        }
    }
}

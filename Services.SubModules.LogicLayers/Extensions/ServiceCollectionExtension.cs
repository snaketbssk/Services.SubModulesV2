using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Authentications.Claims;
using Services.SubModules.LogicLayers.Authentications.Handlers.Entities;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Profiles;
using Services.SubModules.LogicLayers.Services;
using Services.SubModules.LogicLayers.Services.Entities;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection serviceCollection)
        {
            // Global services
            serviceCollection.AddCache();
            serviceCollection.AddGrpc();
            serviceCollection.AddControllers();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddCors();
            serviceCollection.AddSwagger();
            serviceCollection.AddAutoMapper();
            serviceCollection.AddAuthorization();
            serviceCollection.AddHttpClient();
            // Singleton services
            serviceCollection.AddSingleton<ITokenService, TokenService>();
            serviceCollection.AddSingleton<IWriterLogService, WriterLogService>();
            serviceCollection.AddSingleton<IExceptionService, ExceptionService>();
            serviceCollection.AddSingleton<ICryptoService, CryptoService>();
            serviceCollection.AddSingleton<ILocalizationService, LocalizationService>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Transient services
            serviceCollection.AddScoped<IIdentityGrpcService, IdentityGrpcService>();
            serviceCollection.AddScoped<IMailerGrpcService, MailerGrpcService>();
            serviceCollection.AddScoped<IStorageGrpcService, StorageGrpcService>();
            serviceCollection.AddScoped<ITelegramGrpcService, TelegramGrpcService>();
            serviceCollection.AddScoped<INotificationsGrpcService, NotificationsGrpcService>();
            serviceCollection.AddScoped<IUserAgentService, UserAgentService>();
            serviceCollection.AddScoped<IActionLoggerService, ActionLoggerService>();
            //
            //serviceCollection.AddInterfacesAndImplementationsToServiceCollection(type => type.Name.EndsWith("Repository"));
            //
            return serviceCollection;
        }

        // Use reflection to find all interfaces and their implementations that match the filter, and add them to the service container
        public static void AddInterfacesAndImplementationsToServiceCollection(this IServiceCollection serviceCollection, Func<Type, bool> filter)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(x => x.GetTypes());
            var list = new Dictionary<object, object>();
            foreach (var type in types)
            {
                if (type.IsInterface && filter(type))
                {
                    var implementations = types.Where(x => x.IsClass && !x.IsAbstract && type.IsAssignableFrom(x) && filter(x));
                    foreach (var implementation in implementations)
                    {
                        list.Add(type, implementation);
                        break;
                        //services.AddScoped(type, implementation);
                    }
                }
            }
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var profileType = typeof(IProfile);
            var profileTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => profileType.IsAssignableFrom(x))
                .Where(x => x.Name != profileType.Name)
                .ToArray();

            serviceCollection.AddAutoMapper(profileTypes);

            return serviceCollection;
        }

        public static IServiceCollection AddCache(this IServiceCollection serviceCollection)
        {
            var cacheService = RedisCacheService.Initialization();

            serviceCollection.AddSingleton(cacheService);
            serviceCollection.AddSingleton<IIdentityCacheService, IdentityCacheService>();
            serviceCollection.AddSingleton<IMailerCacheService, MailerCacheService>();
            serviceCollection.AddSingleton<INotificationsCacheService, NotificationsCacheService>();
            serviceCollection.AddSingleton<IStorageCacheService, StorageCacheService>();
            serviceCollection.AddSingleton<ITelegramCacheService, TelegramCacheService>();

            return serviceCollection;
        }

        public static IServiceCollection AddGrpcAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(x =>
                {
                    x.DefaultScheme = SchemeConstant.DEFAULT;
                    x.DefaultAuthenticateScheme = SchemeConstant.DEFAULT;
                    x.DefaultChallengeScheme = SchemeConstant.DEFAULT;
                })
                .AddScheme<
                    IdentityGrpcValidateAuthenticationSchemeOptions,
                    IdentityGrpcValidateAuthenticationHandler>(SchemeConstant.DEFAULT, options => { })
                .AddScheme<
                    GrpcValidateAuthenticationSchemeOptions,
                    GrpcValidateAuthenticationHandler>(SchemeConstant.GRPC, options => { });

            return serviceCollection;
        }

        private static IServiceCollection AddAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(x =>
            {
                x.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                var typeClaims = Enum.GetNames(typeof(TypeClaim));
                var valueClaims = Enum.GetNames(typeof(ValueClaim));
                foreach (var typeClaim in typeClaims)
                {
                    foreach (var valueClaim in valueClaims)
                    {
                        var namePolicy = $"{typeClaim}{valueClaim}";
                        x.AddPolicy(namePolicy, policy => policy.RequireClaim(typeClaim, valueClaim));
                    }
                }
            });

            return serviceCollection;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
            var rootAspNetCore = AspNetCoreEnvironmentConfiguration<AspNetCoreEnvironmentRoot>.Instance.GetRoot();
            var rootSwagger = SwaggerEnvironmentConfiguration<SwaggerEnvironmentRoot>.Instance.GetRoot();

            var xmlFile = $"{rootAspNetCore.ASSEMBLY}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (rootSwagger.ACTIVE.HasValue && rootSwagger.ACTIVE.Value)
            {
                serviceCollection.AddSwaggerGen(x =>
                {
                    x.IncludeXmlComments(xmlPath);
                    if (rootSwagger.AUTHENTICATION.HasValue && rootSwagger.AUTHENTICATION.Value)
                    {
                        x.AddSecurityDefinition(HeaderConstant.AUTHORIZATION, new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = $"Please insert {HeaderConstant.AUTHORIZATION} into field",
                            Name = HeaderConstant.AUTHORIZATION,
                            Type = SecuritySchemeType.ApiKey
                        });
                        x.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = HeaderConstant.AUTHORIZATION
                                    }
                                },
                                new string[] { }
                            }
                        });
                    }
                });
            }
            return serviceCollection;
        }
        public static IServiceCollection AddDbContext<T>(this IServiceCollection serviceCollection, string? connectionString) where T : DbContext
        {
            serviceCollection.AddDbContext<T>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return serviceCollection;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
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
            return serviceCollection;
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
            if (SwaggerConfiguration<SwaggerRoot>.Instance.Root.IsActiveSwagger)
            {
                serviceCollection.AddSwaggerGen(x =>
                {
                    var fileSwagger = SwaggerConfiguration<SwaggerRoot>.Instance.Root.NameFile;
                    x.IncludeXmlComments(fileSwagger);
                    if (SwaggerConfiguration<SwaggerRoot>.Instance.Root.IsAuthenticationSwagger)
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
        public static IServiceCollection AddDbContext<T>(this IServiceCollection serviceCollection) where T : DbContext
        {
            serviceCollection.AddDbContext<T>(options =>
            {
                options.UseSqlServer(EntityFrameworkConfiguration<EntityFrameworkRoot>
                    .Instance
                    .Root
                    .ConnectionEntityFramework);
            });
            return serviceCollection;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Authentications.Handlers.Entities;
using Services.SubModules.LogicLayers.Authentications.SchemeOptions.Entities;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Models.Mappings.Entities;
using Services.SubModules.LogicLayers.Services;
using Services.SubModules.LogicLayers.Services.Entities;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection serviceCollection)
        {
            // Global services
            serviceCollection.AddGrpc();
            serviceCollection.AddControllers();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddCors();
            serviceCollection.AddSwagger();
            serviceCollection.AddAutoMapper(x => x.AddProfile(new AutoMapping()));
            // Singleton services
            serviceCollection.AddSingleton<ITokenService, TokenService>();
            serviceCollection.AddSingleton<ILogService, LogService>();
            serviceCollection.AddSingleton<ICryptoService, CryptoService>();
            // Transient services
            serviceCollection.AddTransient<IIdentityGrpcService, IdentityGrpcService>();
            serviceCollection.AddTransient<IMailerGrpcService, MailerGrpcService>();
            serviceCollection.AddTransient<IStorageGrpcService, StorageGrpcService>();
            serviceCollection.AddTransient<ITelegramGrpcService, TelegramGrpcService>();
            //
            return serviceCollection;
        }
        public static IServiceCollection AddConfigurationAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(x =>
                {
                    x.DefaultScheme = SchemeConstant.DEFAULT;
                })
                .AddScheme<
                    IdentityAuthenticationSchemeOptions,
                    IdentityAuthenticationHandler>(SchemeConstant.DEFAULT, options => { });
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

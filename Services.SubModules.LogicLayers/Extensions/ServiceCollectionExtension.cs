using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Constants;
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
            // Singleton services
            serviceCollection.AddSingleton<ITokenService, TokenService>();
            // Transient services
            serviceCollection.AddTransient<IIdentityGrpcService, IdentityGrpcService>();
            serviceCollection.AddTransient<IMailerGrpcService, MailerGrpcService>();
            serviceCollection.AddTransient<IStorageGrpcService, StorageGrpcService>();
            serviceCollection.AddTransient<ITelegramGrpcService, TelegramGrpcService>();
            //
            return serviceCollection;
        }
        private static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
            if (SwaggerConfiguration<SwaggerRoot>.Instance.Root.IsActiveSwagger)
            {
                serviceCollection.AddSwaggerGen(c =>
                {
                    var fileSwagger = SwaggerConfiguration<SwaggerRoot>.Instance.Root.NameFile;
                    c.IncludeXmlComments(fileSwagger);
                    if (SwaggerConfiguration<SwaggerRoot>.Instance.Root.IsAuthenticationSwagger)
                    {
                        c.AddSecurityDefinition(HeaderConstant.AUTHORIZATION, new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = $"Please insert {HeaderConstant.AUTHORIZATION} into field",
                            Name = HeaderConstant.AUTHORIZATION,
                            Type = SecuritySchemeType.ApiKey
                        });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
    }
}

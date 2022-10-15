using Microsoft.AspNetCore.Builder;
using Prometheus;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Middlewares.Entities;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddConfiguration(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.AddSwagger();
            applicationBuilder.AddCors();
            applicationBuilder.AddMiddlewares();
            applicationBuilder.UseRouting();
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();
            applicationBuilder.AddPrometheus();
            return applicationBuilder;
        }
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder applicationBuilder)
        {
            if (SwaggerConfiguration<SwaggerRoot>.Instance.Root.IsActiveSwagger)
            {
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(
                        SwaggerConfiguration<SwaggerRoot>.Instance.Root.Url,
                        SwaggerConfiguration<SwaggerRoot>.Instance.Root.Name);
                });
            }
            return applicationBuilder;
        }
        public static IApplicationBuilder AddCors(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors(x => x.AllowAnyOrigin()
                                             .AllowAnyMethod()
                                             .AllowAnyHeader());
            return applicationBuilder;
        }
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<LocalizationMiddleware>();
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
            return applicationBuilder;
        }
        private static IApplicationBuilder AddPrometheus(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseHttpMetrics();
            applicationBuilder.UseGrpcMetrics();
            return applicationBuilder;
        }
    }
}

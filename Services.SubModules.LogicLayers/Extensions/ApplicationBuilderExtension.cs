using Microsoft.AspNetCore.Builder;
using Prometheus;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Middlewares.Entities;

namespace Services.SubModules.LogicLayers.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddConfiguration(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.AddSwagger();
            //applicationBuilder.AddCors();
            applicationBuilder.AddMiddlewares();
            applicationBuilder.UseRouting();
            //applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();
            applicationBuilder.AddPrometheus();
            return applicationBuilder;
        }
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder applicationBuilder)
        {
            var root = SwaggerEnvironmentConfiguration<SwaggerEnvironmentRoot>.Instance.GetRoot();

            if (root.ACTIVE.HasValue && root.ACTIVE.Value)
            {
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(c =>
                {
                    //c.SwaggerEndpoint(
                    //    SwaggerEnvironmentConfiguration<SwaggerEnvironmentRoot>.Instance.Root.Url,
                    //    SwaggerEnvironmentConfiguration<SwaggerEnvironmentRoot>.Instance.Root.Name);
                });
            }
            return applicationBuilder;
        }
        public static IApplicationBuilder AddCors(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors(x => x.AllowAnyOrigin()
                                             .WithOrigins("http://10.0.0.1:3000,http://10.0.0.2:3000")
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

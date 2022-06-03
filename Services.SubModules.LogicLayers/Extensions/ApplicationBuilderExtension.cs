using Microsoft.AspNetCore.Builder;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Constants;
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
            applicationBuilder.UseCors(CorsConstant.POLICY);
            return applicationBuilder;
        }
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();
            return applicationBuilder;
        }
    }
}

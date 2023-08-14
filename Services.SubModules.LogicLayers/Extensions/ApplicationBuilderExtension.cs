using Microsoft.AspNetCore.Builder;
using Prometheus;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Constants;
using Services.SubModules.LogicLayers.Middlewares.Entities;

namespace Services.SubModules.LogicLayers.Extensions
{
    /// <summary>
    /// Extension methods for configuring the application using the IApplicationBuilder interface.
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Adds various configuration components to the application builder.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder instance.</param>
        /// <returns>The configured IApplicationBuilder instance.</returns>
        public static IApplicationBuilder AddConfiguration(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.AddSwagger();            // Adds Swagger support
            applicationBuilder.AddServiceCors();        // Adds CORS configuration
            applicationBuilder.AddMiddlewares();        // Adds custom middlewares
            applicationBuilder.UseRouting();            // Configures routing
            applicationBuilder.UseAuthentication();     // Enables authentication
            applicationBuilder.UseAuthorization();      // Enables authorization
            applicationBuilder.AddPrometheus();         // Adds Prometheus metrics
            return applicationBuilder;
        }

        /// <summary>
        /// Configures Swagger support if the corresponding configuration is active.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder instance.</param>
        /// <returns>The configured IApplicationBuilder instance.</returns>
        public static IApplicationBuilder AddSwagger(this IApplicationBuilder applicationBuilder)
        {
            var root = SwaggerEnvironmentConfiguration<SwaggerEnvironmentRoot>.Instance.GetRoot();

            if (root.ACTIVE.HasValue && root.ACTIVE.Value)
            {
                applicationBuilder.UseSwagger();    // Uses Swagger middleware
                applicationBuilder.UseSwaggerUI(c =>
                {
                    // Additional SwaggerUI configuration can be added here
                });
            }

            // Returns the updated application builder instance
            return applicationBuilder;
        }

        /// <summary>
        /// Configures CORS for the application.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder instance.</param>
        /// <returns>The configured IApplicationBuilder instance.</returns>
        public static IApplicationBuilder AddServiceCors(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors(CorsConstant.POLICY);   // Configures CORS policy

            // Returns the updated application builder instance
            return applicationBuilder;
        }

        /// <summary>
        /// Adds custom middlewares to the application.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder instance.</param>
        /// <returns>The configured IApplicationBuilder instance.</returns>
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<LocalizationMiddleware>();   // Adds localization middleware
            applicationBuilder.UseMiddleware<ExceptionMiddleware>();     // Adds exception handling middleware

            // Returns the updated application builder instance
            return applicationBuilder;
        }

        /// <summary>
        /// Adds Prometheus metrics to the application.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder instance.</param>
        /// <returns>The configured IApplicationBuilder instance.</returns>
        private static IApplicationBuilder AddPrometheus(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseHttpMetrics();   // Adds HTTP metrics
            applicationBuilder.UseGrpcMetrics();   // Adds gRPC metrics

            // Returns the updated application builder instance
            return applicationBuilder;
        }
    }
}

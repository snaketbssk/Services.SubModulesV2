using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// An abstract base class for gRPC services.
    /// Manages gRPC channel setup, headers, and disposal.
    /// </summary>
    public abstract class GrpcService : IDisposable
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Gets or sets the HttpClientHandler used for gRPC communication.
        /// </summary>
        public HttpClientHandler HttpClientHandler { get; private set; }

        /// <summary>
        /// Gets or sets the GrpcChannel used for communication with the gRPC server.
        /// </summary>
        public GrpcChannel GrpcChannel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrpcService"/> class.
        /// </summary>
        /// <param name="url">The URL of the gRPC server.</param>
        /// <param name="tokenService">The token service for managing authentication tokens.</param>
        public GrpcService(string? url, ITokenService tokenService)
        {
            ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));

            _tokenService = tokenService;
            HttpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            GrpcChannel = GrpcChannel.ForAddress(
                url,
                new GrpcChannelOptions
                {
                    HttpHandler = HttpClientHandler
                });
        }

        /// <summary>
        /// Gets custom headers to be included in the gRPC request.
        /// </summary>
        /// <returns>The metadata containing the headers.</returns>
        protected virtual Metadata GetHeaders()
        {
            var result = new Metadata();
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimConstant.ROLE, RoleConstant.SERVICE));

            var token = _tokenService.GenerateToken(claims);
            result.Add(HeaderConstant.AUTHORIZATION, $"{JwtBearerDefaults.AuthenticationScheme} {token}");
            return result;
        }

        /// <summary>
        /// Gets the deadline for the gRPC request based on the configured timeout.
        /// </summary>
        /// <returns>The deadline for the gRPC request.</returns>
        protected virtual DateTime GetDeadline()
        {
            var result = DateTime.UtcNow.AddSeconds(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().TIMEOUT ?? 60);
            return result;
        }

        /// <summary>
        /// Destructor for cleaning up resources.
        /// </summary>
        ~GrpcService()
        {
            Dispose();
        }

        /// <summary>
        /// Disposes of the allocated resources.
        /// </summary>
        public void Dispose()
        {
            if (GrpcChannel != null) GrpcChannel.Dispose();
            if (HttpClientHandler != null) HttpClientHandler.Dispose();
        }
    }
}

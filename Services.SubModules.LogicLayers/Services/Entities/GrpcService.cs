using Grpc.Core;
using Grpc.Net.Client;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using Services.SubModules.LogicLayers.Authentications.Claims;
using Services.SubModules.LogicLayers.Constants;
using System.Security.Claims;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class GrpcService : IDisposable
    {
        private readonly ITokenService _tokenService;
        public HttpClientHandler HttpClientHandler { get; private set; }
        public GrpcChannel GrpcChannel { get; private set; }
        public GrpcService(string url, ITokenService tokenService)
        {
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
        protected virtual Metadata GetHeaders()
        {
            var result = new Metadata();
            var claims = new List<Claim>();

            var serviceTypeClaim = nameof(TypeClaim.Service);
            foreach (var valueClaim in Enum.GetNames(typeof(ValueClaim)))
            {
                var claim = new Claim(serviceTypeClaim, valueClaim);
                claims.Add(claim);
            }

            var token = _tokenService.GenerateToken(claims);
            result.Add(HeaderConstant.AUTHORIZATION, token);
            return result;
        }
        protected virtual DateTime GetDeadline()
        {
            var result = DateTime.UtcNow.AddSeconds(GrpcConfiguration<GrpcRoot>.Instance.Root.SecondsTimeout);
            return result;
        }
        ~GrpcService()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (GrpcChannel != null) GrpcChannel.Dispose();
            if (HttpClientHandler != null) HttpClientHandler.Dispose();
        }
    }
}

﻿using Microsoft.Extensions.Logging;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class TelegramGrpcService : GrpcService, ITelegramGrpcService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<TelegramGrpcService> _logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IExceptionService _exceptionService;

        public TelegramGrpcService(
            IExceptionService exceptionService,
            ITokenService tokenService,
            ILogger<TelegramGrpcService> logger)
            : base(GrpcEnvironmentConfiguration<GrpcEnvironmentRoot>.Instance.GetRoot().TELEGRAM_HOST, tokenService)
        {
            _logger = logger;
            _exceptionService = exceptionService;
        }

        public async Task<bool> SendMessageAsync(IMapping<MessageTelegramGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendMessageAsync(request: request,
                                                           headers: headers,
                                                           deadline: deadline,
                                                           cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendMessageAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        public async Task<bool> SendMediaAsync(IMapping<MediaFilesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendMediaAsync(request: request,
                                                         headers: headers,
                                                         deadline: deadline,
                                                         cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendMediaAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }

        public async Task<bool> SendImagesAsync(IMapping<MediaImagesGrpcRequest> mapping, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = new TelegramGrpc.TelegramGrpcClient(GrpcChannel);
                var request = mapping.Map();
                var headers = GetHeaders();
                var deadline = GetDeadline();
                var result = await client.SendImagesAsync(request: request,
                                                          headers: headers,
                                                          deadline: deadline,
                                                          cancellationToken: cancellationToken);
                return true;
            }
            catch (Exception exception)
            {
                await _exceptionService.ExecuteAsync(method: nameof(TelegramGrpcService),
                                                     path: nameof(SendImagesAsync),
                                                     exception: exception,
                                                     cancellationToken);
                return false;
            }
        }
    }
}

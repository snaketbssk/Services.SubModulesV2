using Services.SubModules.LogicLayers.Models.Mappings;
using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IWalletsGrpcService
    {
        Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> CreditAsync(IMapping<TransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
        Task<(bool isSuccessful, TransactionWalletsGrpcResponse?)> DebitAsync(IMapping<TransactionWalletsGrpcRequest> mapping, CancellationToken cancellationToken = default);
    }
}

using Services.SubModules.LogicLayers.Models.Requests;
using Services.SubModules.LogicLayers.Models.Responses;
using System.Collections.Generic; // Add this namespace for IEnumerable
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for common operations related to currencies.
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// Retrieves a list of currencies.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An enumerable of ICurrencyResponse instances.</returns>
        Task<IEnumerable<ICurrencyResponse>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a currency using the specified request.
        /// </summary>
        /// <param name="request">The request containing the currency identifier.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. An ICurrencyResponse instance.</returns>
        Task<ICurrencyResponse> GetCurrencyAsync(IIdRequest request, CancellationToken cancellationToken = default);
    }
}

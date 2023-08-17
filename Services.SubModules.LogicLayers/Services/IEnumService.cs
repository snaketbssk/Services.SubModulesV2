using Services.SubModules.LogicLayers.Models.Responses;
using System;
using System.Collections.Generic; // Add this namespace for IEnumerable

namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for retrieving enumeration values and their metadata.
    /// </summary>
    public interface IEnumService
    {
        /// <summary>
        /// Gets a collection of enumeration responses for a specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The enum type for which to retrieve enumeration responses.</typeparam>
        /// <returns>An enumerable of IEnumResponse instances representing the enumeration values.</returns>
        IEnumerable<IEnumResponse> Get<TEnum>() where TEnum : Enum;
    }
}

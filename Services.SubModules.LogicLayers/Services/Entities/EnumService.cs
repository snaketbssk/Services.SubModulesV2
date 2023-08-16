using Services.SubModules.LogicLayers.Models.Responses;
using Services.SubModules.LogicLayers.Models.Responses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Represents a service for working with enums.
    /// </summary>
    public class EnumService : IEnumService
    {
        /// <summary>
        /// Gets a list of enum responses for a specified enum type.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <returns>A list of enum responses.</returns>
        public IEnumerable<IEnumResponse> Get<TEnum>() where TEnum : Enum
        {
            var result = new List<IEnumResponse>();

            // Get all values from CommonEnumResponse enum and convert to EnumResponse
            result.AddRange(Enum.GetValues(typeof(CommonEnumResponse))
                                .Cast<CommonEnumResponse>()
                                .Select(value => EnumResponse.FromEnum(value)));

            // Get all values from the specified enum type and convert to EnumResponse
            result.AddRange(Enum.GetValues(typeof(TEnum))
                                .Cast<TEnum>()
                                .Select(value => EnumResponse.FromEnum(value)));

            return result;
        }
    }
}

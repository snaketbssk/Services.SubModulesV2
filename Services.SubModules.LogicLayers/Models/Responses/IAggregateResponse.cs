using System;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents an interface for aggregate response models.
    /// </summary>
    public interface IAggregateResponse
    {
        /// <summary>
        /// Gets or sets the amount associated with the aggregate.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the start date of the aggregate period.
        /// </summary>
        DateTime FromAggregateAt { get; set; }

        /// <summary>
        /// Gets or sets the end date of the aggregate period.
        /// </summary>
        DateTime ToAggregateAt { get; set; }
    }
}

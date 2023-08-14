using System.Collections.Generic;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for a list of identifiers.
    /// </summary>
    public class IdsRequest : IIdsRequest
    {
        /// <summary>
        /// Gets or sets the list of IdRequests.
        /// </summary>
        public List<IdRequest> Ids { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdsRequest"/> class with default values.
        /// </summary>
        public IdsRequest()
        {
            // Initialize the list of IdRequests.
            Ids = new List<IdRequest>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdsRequest"/> class with a single IdRequest.
        /// </summary>
        /// <param name="id">The IdRequest to add to the list.</param>
        public IdsRequest(IdRequest id)
        {
            // Initialize the list of IdRequests with a single item.
            Ids = new List<IdRequest>() { id };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdsRequest"/> class with a collection of IdRequests.
        /// </summary>
        /// <param name="ids">The collection of IdRequests to add to the list.</param>
        public IdsRequest(IEnumerable<IdRequest> ids)
        {
            // Initialize the list of IdRequests with the provided collection.
            Ids = new List<IdRequest>(ids);
        }
    }
}

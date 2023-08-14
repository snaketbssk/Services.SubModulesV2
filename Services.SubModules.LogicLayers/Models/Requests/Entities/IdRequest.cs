using Google.Protobuf;

namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents a request for an identifier of type Guid.
    /// </summary>
    public class IdRequest : BaseIdRequest<Guid>, IIdRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdRequest"/> class with default values.
        /// </summary>
        public IdRequest() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdRequest"/> class with the provided Guid identifier.
        /// </summary>
        /// <param name="id">The Guid identifier.</param>
        public IdRequest(Guid id) : base(id)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdRequest"/> class with the provided byte array representation of a Guid identifier.
        /// </summary>
        /// <param name="bytes">The byte array representation of the Guid identifier.</param>
        public IdRequest(byte[] bytes) : base(new Guid(bytes))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdRequest"/> class with the provided ByteString representation of a Guid identifier.
        /// </summary>
        /// <param name="bytes">The ByteString representation of the Guid identifier.</param>
        public IdRequest(ByteString bytes) : base(new Guid(bytes.ToByteArray()))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdRequest"/> class with the provided string representation of a Guid identifier.
        /// </summary>
        /// <param name="id">The string representation of the Guid identifier.</param>
        public IdRequest(string id) : base(Guid.Parse(id))
        {

        }

        /// <summary>
        /// Converts the Guid identifier to its string representation.
        /// </summary>
        /// <returns>The string representation of the Guid identifier.</returns>
        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}

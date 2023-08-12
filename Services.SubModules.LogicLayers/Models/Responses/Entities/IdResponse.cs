using Google.Protobuf;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response class for an entity with an ID of type Guid.
    /// </summary>
    public class IdResponse : BaseIdResponse<Guid>, IIdResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdResponse"/> class with a default ID.
        /// </summary>
        public IdResponse() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdResponse"/> class with a specified ID.
        /// </summary>
        /// <param name="id">The ID value.</param>
        public IdResponse(Guid id) : base(id)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdResponse"/> class with a byte array representation of the ID.
        /// </summary>
        /// <param name="bytes">The byte array representing the ID.</param>
        public IdResponse(byte[] bytes) : base(new Guid(bytes))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdResponse"/> class with a ByteString representation of the ID.
        /// </summary>
        /// <param name="bytes">The ByteString representing the ID.</param>
        public IdResponse(ByteString bytes) : base(new Guid(bytes.ToByteArray()))
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdResponse"/> class with a string representation of the ID.
        /// </summary>
        /// <param name="id">The string representation of the ID.</param>
        public IdResponse(string id) : base(Guid.Parse(id))
        {

        }

        /// <summary>
        /// Converts the ID to its string representation.
        /// </summary>
        /// <returns>The string representation of the ID.</returns>
        public override string ToIdString()
        {
            var result = Id.ToString();
            return result;
        }
    }
}

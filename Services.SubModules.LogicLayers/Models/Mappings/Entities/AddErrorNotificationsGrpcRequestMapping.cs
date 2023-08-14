using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from custom entity to the protobuf request message for adding error notifications.
    /// </summary>
    public class AddErrorNotificationsGrpcRequestMapping : Mapping<AddErrorNotificationsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the user ID associated with the error notification.
        /// </summary>
        public Guid IdUser { get; set; }

        /// <summary>
        /// Gets or sets the title of the error notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the error notification.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddErrorNotificationsGrpcRequestMapping"/> class
        /// with the specified user ID, title, and content.
        /// </summary>
        /// <param name="idUser">The user ID associated with the error notification.</param>
        /// <param name="title">The title of the error notification.</param>
        /// <param name="content">The content of the error notification.</param>
        public AddErrorNotificationsGrpcRequestMapping(Guid idUser, string title, string content)
        {
            IdUser = idUser;
            Title = title;
            Content = content;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf request message for adding error notifications.
        /// </summary>
        /// <returns>The mapped <see cref="AddErrorNotificationsGrpcRequest"/> instance.</returns>
        public override AddErrorNotificationsGrpcRequest Map()
        {
            var result = new AddErrorNotificationsGrpcRequest
            {
                IdUser = ByteString.CopyFrom(IdUser.ToByteArray()),
                Title = Title,
                Content = Content
            };
            return result;
        }

        /// <summary>
        /// Updates an existing protobuf request message instance with the properties of this mapping.
        /// This method is not implemented and will throw an exception.
        /// </summary>
        /// <param name="result">The existing protobuf request message to be updated.</param>
        /// <returns>The updated <see cref="AddErrorNotificationsGrpcRequest"/> instance.</returns>
        public override AddErrorNotificationsGrpcRequest Update(AddErrorNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

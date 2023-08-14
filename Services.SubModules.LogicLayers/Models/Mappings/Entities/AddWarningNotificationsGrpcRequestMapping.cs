using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping from custom entity to the protobuf request message for adding warning notifications.
    /// </summary>
    public class AddWarningNotificationsGrpcRequestMapping : Mapping<AddWarningNotificationsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public Guid IdUser { get; set; }

        /// <summary>
        /// Gets or sets the title of the warning notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the warning notification.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddWarningNotificationsGrpcRequestMapping"/> class
        /// with the specified user ID, title, and content.
        /// </summary>
        /// <param name="idUser">The ID of the user.</param>
        /// <param name="title">The title of the warning notification.</param>
        /// <param name="content">The content of the warning notification.</param>
        public AddWarningNotificationsGrpcRequestMapping(Guid idUser, string title, string content)
        {
            IdUser = idUser;
            Title = title;
            Content = content;
        }

        /// <summary>
        /// Maps the properties of this instance to a protobuf request message for adding warning notifications.
        /// </summary>
        /// <returns>The mapped <see cref="AddWarningNotificationsGrpcRequest"/> instance.</returns>
        public override AddWarningNotificationsGrpcRequest Map()
        {
            var result = new AddWarningNotificationsGrpcRequest
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
        /// <returns>The updated <see cref="AddWarningNotificationsGrpcRequest"/> instance.</returns>
        public override AddWarningNotificationsGrpcRequest Update(AddWarningNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for creating group notifications using gRPC requests.
    /// </summary>
    public class CreateGroupNotificationsGrpcRequestMapping : Mapping<CreateGroupNotificationsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the group.
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the notification.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the language for the notification.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the type of the notification.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Maps the properties of this instance to a CreateGroupNotificationsGrpcRequest object.
        /// </summary>
        /// <returns>The mapped CreateGroupNotificationsGrpcRequest object.</returns>
        public override CreateGroupNotificationsGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new CreateGroupNotificationsGrpcRequest()
            {
                GroupId = GroupId.ToString() ?? "",
                Data = data ?? "",
                Language = Language ?? "",
                Type = Type ?? ""
            };

            return result;
        }

        /// <summary>
        /// Updates an existing CreateGroupNotificationsGrpcRequest object.
        /// </summary>
        /// <param name="result">The existing object to be updated.</param>
        /// <returns>The updated CreateGroupNotificationsGrpcRequest object.</returns>
        public override CreateGroupNotificationsGrpcRequest Update(CreateGroupNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

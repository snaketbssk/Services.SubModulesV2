using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for creating user notifications using gRPC requests.
    /// </summary>
    public class CreateUserNotificationsGrpcRequestMapping : Mapping<CreateUserNotificationsGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public Guid UserId { get; set; }

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
        /// Initializes a new instance of the <see cref="CreateUserNotificationsGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="data">The data associated with the notification.</param>
        /// <param name="language">The language for the notification.</param>
        /// <param name="type">The type of the notification.</param>
        public CreateUserNotificationsGrpcRequestMapping(Guid userId, object data, string? language, string? type)
        {
            UserId = userId;
            Data = data;
            Language = language;
            Type = type;
        }

        /// <summary>
        /// Maps the properties of this instance to a CreateUserNotificationsGrpcRequest object.
        /// </summary>
        /// <returns>The mapped CreateUserNotificationsGrpcRequest object.</returns>
        public override CreateUserNotificationsGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new CreateUserNotificationsGrpcRequest()
            {
                UserId = UserId.ToString() ?? "",
                Data = data ?? "",
                Language = Language ?? "",
                Type = Type ?? ""
            };

            return result;
        }

        /// <summary>
        /// Updates an existing CreateUserNotificationsGrpcRequest object.
        /// This method is not implemented.
        /// </summary>
        /// <param name="result">The existing object to be updated.</param>
        /// <returns>The updated CreateUserNotificationsGrpcRequest object.</returns>
        public override CreateUserNotificationsGrpcRequest Update(CreateUserNotificationsGrpcRequest result)
        {
            throw new NotImplementedException("Update method is not implemented.");
        }
    }
}

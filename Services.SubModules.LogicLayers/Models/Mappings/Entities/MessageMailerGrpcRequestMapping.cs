using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting MessageMailerGrpcRequestMapping to MessageMailerGrpcRequest.
    /// </summary>
    public class MessageMailerGrpcRequestMapping : Mapping<MessageMailerGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the type of the message for the mailer.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the email address for the mailer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the mailer message.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the language of the mailer message.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the date of the mailer message.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMailerGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="type">The type of the message for the mailer.</param>
        /// <param name="address">The email address for the mailer.</param>
        /// <param name="data">The data associated with the mailer message.</param>
        /// <param name="language">The language of the mailer message.</param>
        /// <param name="date">The date of the mailer message.</param>
        public MessageMailerGrpcRequestMapping(
            string type,
            string address,
            object data,
            string language,
            DateTime date)
        {
            Type = type;
            Address = address;
            Data = data;
            Language = language;
            Date = date;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of MessageMailerGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of MessageMailerGrpcRequest.</returns>
        public override MessageMailerGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MessageMailerGrpcRequest
            {
                Type = Type ?? "",
                Address = Address ?? "",
                Data = data ?? "",
                Date = Date.Ticks,
                Language = Language ?? ""
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of MessageMailerGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of MessageMailerGrpcRequest to be updated.</param>
        /// <returns>The updated instance of MessageMailerGrpcRequest.</returns>
        public override MessageMailerGrpcRequest Update(MessageMailerGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

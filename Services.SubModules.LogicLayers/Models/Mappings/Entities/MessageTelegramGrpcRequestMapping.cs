using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting MessageTelegramGrpcRequestMapping to MessageTelegramGrpcRequest.
    /// </summary>
    public class MessageTelegramGrpcRequestMapping : Mapping<MessageTelegramGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the type of the message for Telegram.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the Telegram message.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the language of the Telegram message.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the date of the Telegram message.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageTelegramGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="type">The type of the message for Telegram.</param>
        /// <param name="data">The data associated with the Telegram message.</param>
        /// <param name="language">The language of the Telegram message.</param>
        /// <param name="date">The date of the Telegram message.</param>
        public MessageTelegramGrpcRequestMapping(
            string type,
            object data,
            string language,
            DateTime date)
        {
            Type = type;
            Data = data;
            Language = language;
            Date = date;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of MessageTelegramGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of MessageTelegramGrpcRequest.</returns>
        public override MessageTelegramGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MessageTelegramGrpcRequest
            {
                Type = Type ?? "",
                Data = data ?? "",
                Date = Date.Ticks,
                Language = Language ?? ""
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of MessageTelegramGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of MessageTelegramGrpcRequest to be updated.</param>
        /// <returns>The updated instance of MessageTelegramGrpcRequest.</returns>
        public override MessageTelegramGrpcRequest Update(MessageTelegramGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MessageTelegramGrpcRequestMapping : Mapping<MessageTelegramGrpcRequest>
    {
        public string Type { get; set; }
        public object Data { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
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

        public override MessageTelegramGrpcRequest Update(MessageTelegramGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

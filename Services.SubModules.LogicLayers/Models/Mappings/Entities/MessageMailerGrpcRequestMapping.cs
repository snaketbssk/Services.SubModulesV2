using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MessageMailerGrpcRequestMapping : Mapping<MessageMailerGrpcRequest>
    {
        public string Type { get; set; }
        public string Address { get; set; }
        public object Data { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
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

        public override MessageMailerGrpcRequest Update(MessageMailerGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

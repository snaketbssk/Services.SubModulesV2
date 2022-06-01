using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MessageTelegramGrpcResponseMapping : Mapping<MessageTelegramGrpcResponse>
    {
        public bool IsSuccess { get; set; }
        public MessageTelegramGrpcResponseMapping(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public override MessageTelegramGrpcResponse Map()
        {
            var result = new MessageTelegramGrpcResponse
            {
                IsSuccess = IsSuccess
            };
            return result;
        }

        public override MessageTelegramGrpcResponse Update(MessageTelegramGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

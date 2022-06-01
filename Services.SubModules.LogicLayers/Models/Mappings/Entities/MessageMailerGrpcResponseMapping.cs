using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MessageMailerGrpcResponseMapping : Mapping<MessageMailerGrpcResponse>
    {
        public bool IsSuccess { get; set; }
        public MessageMailerGrpcResponseMapping(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public override MessageMailerGrpcResponse Map()
        {
            var result = new MessageMailerGrpcResponse
            {
                IsSuccess = IsSuccess
            };
            return result;
        }

        public override MessageMailerGrpcResponse Update(MessageMailerGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

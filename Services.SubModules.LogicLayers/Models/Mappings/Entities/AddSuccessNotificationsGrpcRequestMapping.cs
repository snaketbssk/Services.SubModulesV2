using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class AddSuccessNotificationsGrpcRequestMapping : Mapping<AddSuccessNotificationsGrpcRequest>
    {
        public Guid IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public AddSuccessNotificationsGrpcRequestMapping(Guid idUser, string title, string content)
        {
            IdUser = idUser;
            Title = title;
            Content = content;
        }

        public override AddSuccessNotificationsGrpcRequest Map()
        {
            var result = new AddSuccessNotificationsGrpcRequest
            {
                IdUser = ByteString.CopyFrom(IdUser.ToByteArray()),
                Title = Title,
                Content = Content
            };
            return result;
        }

        public override AddSuccessNotificationsGrpcRequest Update(AddSuccessNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

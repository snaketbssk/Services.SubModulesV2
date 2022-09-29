using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class AddErrorNotificationsGrpcRequestMapping : Mapping<AddErrorNotificationsGrpcRequest>
    {
        public Guid IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public AddErrorNotificationsGrpcRequestMapping(Guid idUser, string title, string content)
        {
            IdUser = idUser;
            Title = title;
            Content = content;
        }

        public override AddErrorNotificationsGrpcRequest Map()
        {
            var result = new AddErrorNotificationsGrpcRequest
            {
                IdUser = ByteString.CopyFrom(IdUser.ToByteArray()),
                Title = Title,
                Content = Content
            };
            return result;
        }

        public override AddErrorNotificationsGrpcRequest Update(AddErrorNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

using Google.Protobuf;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class AddWarningNotificationsGrpcRequestMapping : Mapping<AddWarningNotificationsGrpcRequest>
    {
        public Guid IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public AddWarningNotificationsGrpcRequestMapping(Guid idUser, string title, string content)
        {
            IdUser = idUser;
            Title = title;
            Content = content;
        }

        public override AddWarningNotificationsGrpcRequest Map()
        {
            var result = new AddWarningNotificationsGrpcRequest
            {
                IdUser = ByteString.CopyFrom(IdUser.ToByteArray()),
                Title = Title,
                Content = Content
            };
            return result;
        }

        public override AddWarningNotificationsGrpcRequest Update(AddWarningNotificationsGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

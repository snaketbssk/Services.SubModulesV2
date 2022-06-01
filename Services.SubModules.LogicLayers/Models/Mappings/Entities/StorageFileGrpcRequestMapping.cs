using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Helpers;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageFileGrpcRequestMapping : Mapping<StorageFileGrpcRequest>
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public StorageFileGrpcRequestMapping(string name, byte[] content)
        {
            Name = name;
            Content = content;
        }
        public StorageFileGrpcRequestMapping(IFormFile formFile)
        {
            Name = formFile.FileName;
            Content = FormFileHelper.ToBytes(formFile);
        }
        public override StorageFileGrpcRequest Map()
        {
            var result = new StorageFileGrpcRequest
            {
                Name = Name,
                Content = ByteString.CopyFrom(Content)
            };
            return result;
        }

        public override StorageFileGrpcRequest Update(StorageFileGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

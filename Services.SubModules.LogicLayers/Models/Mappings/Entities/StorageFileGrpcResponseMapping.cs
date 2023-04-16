using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageFileGrpcResponseMapping : Mapping<StorageFileGrpcResponse>
    {
        public string Name { get; set; }
        public StorageFileGrpcResponseMapping(string name)
        {
            Name = name;
        }
        public override StorageFileGrpcResponse Map()
        {
            var result = new StorageFileGrpcResponse
            {
                Name = Name
            };
            return result;
        }

        public override StorageFileGrpcResponse Update(StorageFileGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

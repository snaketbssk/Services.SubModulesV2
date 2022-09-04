using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageReadFileGrpcRequestMapping : Mapping<StorageReadFileGrpcRequest>
    {
        public string Name { get; set; }
        public StorageReadFileGrpcRequestMapping(string name)
        {
            Name = name;
        }
        public override StorageReadFileGrpcRequest Map()
        {
            var result = new StorageReadFileGrpcRequest
            {
                Name = Name
            };
            return result;
        }

        public override StorageReadFileGrpcRequest Update(StorageReadFileGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

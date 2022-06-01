using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageFileGrpcResponseMapping : Mapping<StorageFileGrpcResponse>
    {
        public bool IsSuccess { get; set; }
        public string Name { get; set; }
        public StorageFileGrpcResponseMapping(bool isSuccess, string name)
        {
            IsSuccess = isSuccess;
            Name = name;
        }
        public override StorageFileGrpcResponse Map()
        {
            var result = new StorageFileGrpcResponse
            {
                IsSuccess = IsSuccess,
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

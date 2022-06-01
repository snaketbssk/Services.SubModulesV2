using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageFilesGrpcResponseMapping : Mapping<StorageFilesGrpcResponse>
    {
        public IEnumerable<StorageFileGrpcResponseMapping> Files { get; set; }
        public StorageFilesGrpcResponseMapping(IEnumerable<StorageFileGrpcResponseMapping> files)
        {
            Files = files;
        }
        public override StorageFilesGrpcResponse Map()
        {
            var result = new StorageFilesGrpcResponse();
            var files = Files.Select(x => x.Map());
            result.Files.AddRange(files);
            return result;
        }

        public override StorageFilesGrpcResponse Update(StorageFilesGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

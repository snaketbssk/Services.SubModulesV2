using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageFilesGrpcRequestMapping : Mapping<StorageFilesGrpcRequest>
    {
        public IEnumerable<StorageFileGrpcRequestMapping> Files { get; set; }
        public StorageFilesGrpcRequestMapping(IEnumerable<StorageFileGrpcRequestMapping> files)
        {
            Files = files;
        }
        public override StorageFilesGrpcRequest Map()
        {
            var result = new StorageFilesGrpcRequest();
            var files = Files.Select(x => x.Map());
            result.Files.AddRange(files);
            return result;
        }

        public override StorageFilesGrpcRequest Update(StorageFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

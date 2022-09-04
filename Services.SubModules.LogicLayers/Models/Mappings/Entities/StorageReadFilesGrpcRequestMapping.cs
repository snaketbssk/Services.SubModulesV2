using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class StorageReadFilesGrpcRequestMapping : Mapping<StorageReadFilesGrpcRequest>
    {
        public List<string> NameFiles { get; set; }
        public StorageReadFilesGrpcRequestMapping(List<string> nameFiles)
        {
            NameFiles = nameFiles;
        }
        public override StorageReadFilesGrpcRequest Map()
        {
            var result = new StorageReadFilesGrpcRequest();
            result.Files.AddRange(NameFiles.Select(x => new StorageReadFileGrpcRequestMapping(x).Map()));
            return result;
        }

        public override StorageReadFilesGrpcRequest Update(StorageReadFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

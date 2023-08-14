using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageReadFilesGrpcRequest.
    /// </summary>
    public class StorageReadFilesGrpcRequestMapping : Mapping<StorageReadFilesGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the list of storage file names to be read.
        /// </summary>
        public List<string> NameFiles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageReadFilesGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="nameFiles">The list of storage file names to be read.</param>
        public StorageReadFilesGrpcRequestMapping(List<string> nameFiles)
        {
            NameFiles = nameFiles;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageReadFilesGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of StorageReadFilesGrpcRequest.</returns>
        public override StorageReadFilesGrpcRequest Map()
        {
            var result = new StorageReadFilesGrpcRequest();
            result.Files.AddRange(NameFiles.Select(x => new StorageReadFileGrpcRequestMapping(x).Map()));
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageReadFilesGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageReadFilesGrpcRequest to be updated.</param>
        /// <returns>The updated instance of StorageReadFilesGrpcRequest.</returns>
        public override StorageReadFilesGrpcRequest Update(StorageReadFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

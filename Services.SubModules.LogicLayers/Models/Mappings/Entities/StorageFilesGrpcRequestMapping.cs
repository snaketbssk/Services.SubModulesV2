using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageFilesGrpcRequest.
    /// </summary>
    public class StorageFilesGrpcRequestMapping : Mapping<StorageFilesGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the collection of storage file mapping requests.
        /// </summary>
        public IEnumerable<StorageFileGrpcRequestMapping> Files { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFilesGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="files">The collection of storage file mapping requests.</param>
        public StorageFilesGrpcRequestMapping(IEnumerable<StorageFileGrpcRequestMapping> files)
        {
            Files = files;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageFilesGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of StorageFilesGrpcRequest.</returns>
        public override StorageFilesGrpcRequest Map()
        {
            var result = new StorageFilesGrpcRequest();
            var files = Files.Select(x => x.Map());
            result.Files.AddRange(files);
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageFilesGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageFilesGrpcRequest to be updated.</param>
        /// <returns>The updated instance of StorageFilesGrpcRequest.</returns>
        public override StorageFilesGrpcRequest Update(StorageFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

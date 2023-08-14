using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageFilesGrpcResponse.
    /// </summary>
    public class StorageFilesGrpcResponseMapping : Mapping<StorageFilesGrpcResponse>
    {
        /// <summary>
        /// Gets or sets the collection of storage file response mapping.
        /// </summary>
        public IEnumerable<StorageFileGrpcResponseMapping> Files { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFilesGrpcResponseMapping"/> class.
        /// </summary>
        /// <param name="files">The collection of storage file response mapping.</param>
        public StorageFilesGrpcResponseMapping(IEnumerable<StorageFileGrpcResponseMapping> files)
        {
            Files = files;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageFilesGrpcResponse.
        /// </summary>
        /// <returns>The mapped instance of StorageFilesGrpcResponse.</returns>
        public override StorageFilesGrpcResponse Map()
        {
            var result = new StorageFilesGrpcResponse();
            var files = Files.Select(x => x.Map());
            result.Files.AddRange(files);
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageFilesGrpcResponse with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageFilesGrpcResponse to be updated.</param>
        /// <returns>The updated instance of StorageFilesGrpcResponse.</returns>
        public override StorageFilesGrpcResponse Update(StorageFilesGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

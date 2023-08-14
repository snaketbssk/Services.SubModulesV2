using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageFileGrpcResponse.
    /// </summary>
    public class StorageFileGrpcResponseMapping : Mapping<StorageFileGrpcResponse>
    {
        /// <summary>
        /// Gets or sets the name of the storage file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFileGrpcResponseMapping"/> class.
        /// </summary>
        /// <param name="name">The name of the storage file.</param>
        public StorageFileGrpcResponseMapping(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageFileGrpcResponse.
        /// </summary>
        /// <returns>The mapped instance of StorageFileGrpcResponse.</returns>
        public override StorageFileGrpcResponse Map()
        {
            var result = new StorageFileGrpcResponse
            {
                Name = Name
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageFileGrpcResponse with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageFileGrpcResponse to be updated.</param>
        /// <returns>The updated instance of StorageFileGrpcResponse.</returns>
        public override StorageFileGrpcResponse Update(StorageFileGrpcResponse result)
        {
            throw new NotImplementedException();
        }
    }
}

using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageReadFileGrpcRequest.
    /// </summary>
    public class StorageReadFileGrpcRequestMapping : Mapping<StorageReadFileGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the name of the storage file to be read.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageReadFileGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="name">The name of the storage file to be read.</param>
        public StorageReadFileGrpcRequestMapping(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageReadFileGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of StorageReadFileGrpcRequest.</returns>
        public override StorageReadFileGrpcRequest Map()
        {
            var result = new StorageReadFileGrpcRequest
            {
                Name = Name
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageReadFileGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageReadFileGrpcRequest to be updated.</param>
        /// <returns>The updated instance of StorageReadFileGrpcRequest.</returns>
        public override StorageReadFileGrpcRequest Update(StorageReadFileGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

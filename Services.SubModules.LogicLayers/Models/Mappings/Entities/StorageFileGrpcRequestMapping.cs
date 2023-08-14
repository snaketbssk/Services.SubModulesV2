using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Services.SubModules.LogicLayers.Helpers;
using Services.SubModules.Protos;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting data to StorageFileGrpcRequest.
    /// </summary>
    public class StorageFileGrpcRequestMapping : Mapping<StorageFileGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the name of the storage file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content of the storage file.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFileGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="name">The name of the storage file.</param>
        /// <param name="content">The content of the storage file as byte array.</param>
        public StorageFileGrpcRequestMapping(string name, byte[] content)
        {
            Name = name;
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFileGrpcRequestMapping"/> class using an IFormFile instance.
        /// </summary>
        /// <param name="formFile">The IFormFile instance representing the uploaded file.</param>
        public StorageFileGrpcRequestMapping(IFormFile formFile)
        {
            Name = formFile.FileName;
            Content = FormFileHelper.ToBytes(formFile);
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of StorageFileGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of StorageFileGrpcRequest.</returns>
        public override StorageFileGrpcRequest Map()
        {
            var result = new StorageFileGrpcRequest
            {
                Name = Name,
                Content = ByteString.CopyFrom(Content)
            };
            return result;
        }

        /// <summary>
        /// Updates an existing instance of StorageFileGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of StorageFileGrpcRequest to be updated.</param>
        /// <returns>The updated instance of StorageFileGrpcRequest.</returns>
        public override StorageFileGrpcRequest Update(StorageFileGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

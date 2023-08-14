using Google.Protobuf;
using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting MediaFilesGrpcRequestMapping to MediaFilesGrpcRequest.
    /// </summary>
    public class MediaFilesGrpcRequestMapping : Mapping<MediaFilesGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the type of the media file.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the media file.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the language of the media file.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the date of the media file.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the list of byte arrays representing media files.
        /// </summary>
        public List<byte[]> Files { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFilesGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="files">The list of byte arrays representing media files.</param>
        /// <param name="type">The type of the media file.</param>
        /// <param name="data">The data associated with the media file.</param>
        /// <param name="language">The language of the media file.</param>
        /// <param name="date">The date of the media file.</param>
        public MediaFilesGrpcRequestMapping(
            List<byte[]> files,
            string type,
            object data,
            string language,
            DateTime date)
        {
            Files = files;
            Type = type;
            Data = data;
            Language = language;
            Date = date;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of MediaFilesGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of MediaFilesGrpcRequest.</returns>
        public override MediaFilesGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MediaFilesGrpcRequest
            {
                Message = new MessageTelegramGrpcRequest
                {
                    Type = Type ?? "",
                    Data = data ?? "",
                    Date = Date.Ticks,
                    Language = Language ?? ""
                }
            };
            result.Files.AddRange(Files.Select(x => new MessageFileGrpcRequest
            {
                Name = "1.webp",
                Content = ByteString.CopyFrom(x)
            }));
            return result;
        }

        /// <summary>
        /// Updates an existing instance of MediaFilesGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of MediaFilesGrpcRequest to be updated.</param>
        /// <returns>The updated instance of MediaFilesGrpcRequest.</returns>
        public override MediaFilesGrpcRequest Update(MediaFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

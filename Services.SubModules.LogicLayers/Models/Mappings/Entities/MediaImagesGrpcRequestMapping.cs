using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    /// <summary>
    /// Represents a mapping class for converting MediaImagesGrpcRequestMapping to MediaImagesGrpcRequest.
    /// </summary>
    public class MediaImagesGrpcRequestMapping : Mapping<MediaImagesGrpcRequest>
    {
        /// <summary>
        /// Gets or sets the type of the media images.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the media images.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the language of the media images.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the date of the media images.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the list of image names.
        /// </summary>
        public List<string> Images { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaImagesGrpcRequestMapping"/> class.
        /// </summary>
        /// <param name="images">The list of image names.</param>
        /// <param name="type">The type of the media images.</param>
        /// <param name="data">The data associated with the media images.</param>
        /// <param name="language">The language of the media images.</param>
        /// <param name="date">The date of the media images.</param>
        public MediaImagesGrpcRequestMapping(
            List<string> images,
            string type,
            object data,
            string language,
            DateTime date)
        {
            Images = images;
            Type = type;
            Data = data;
            Language = language;
            Date = date;
        }

        /// <summary>
        /// Maps the properties of the current instance to an instance of MediaImagesGrpcRequest.
        /// </summary>
        /// <returns>The mapped instance of MediaImagesGrpcRequest.</returns>
        public override MediaImagesGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MediaImagesGrpcRequest
            {
                Message = new MessageTelegramGrpcRequest
                {
                    Type = Type ?? "",
                    Data = data ?? "",
                    Date = Date.Ticks,
                    Language = Language ?? ""
                }
            };
            result.Images.AddRange(Images.Select(x => new MessageImageGrpcRequest
            {
                Name = x
            }));

            return result;
        }

        /// <summary>
        /// Updates an existing instance of MediaImagesGrpcRequest with the properties of the current instance.
        /// This method is intended to be overridden in derived classes.
        /// </summary>
        /// <param name="result">The existing instance of MediaImagesGrpcRequest to be updated.</param>
        /// <returns>The updated instance of MediaImagesGrpcRequest.</returns>
        public override MediaImagesGrpcRequest Update(MediaImagesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

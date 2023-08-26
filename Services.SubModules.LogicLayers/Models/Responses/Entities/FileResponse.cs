using Microsoft.AspNetCore.Mvc;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response object that encapsulates file-related information.
    /// </summary>
    public class FileResponse : IFileResponse
    {
        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content of the file as a byte array.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileResponse"/> class.
        /// </summary>
        /// <param name="type">The type of the file.</param>
        /// <param name="name">The name of the file.</param>
        /// <param name="content">The content of the file as a byte array.</param>
        public FileResponse(string type, string name, byte[] content)
        {
            Type = type;
            Name = name;
            Content = content;
        }

        /// <summary>
        /// Converts the FileResponse to a FileContentResult object for ASP.NET Core.
        /// </summary>
        /// <returns>A FileContentResult containing the file content.</returns>
        public FileContentResult ToFile()
        {
            // Create a new FileContentResult instance using the file content, type, and name.
            var result = new FileContentResult(Content, Type) { FileDownloadName = Name };
            return result;
        }
    }
}

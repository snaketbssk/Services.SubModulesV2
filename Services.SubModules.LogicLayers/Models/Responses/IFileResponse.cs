using Microsoft.AspNetCore.Mvc;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents a response interface for files.
    /// </summary>
    public interface IFileResponse
    {
        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the content of the file as a byte array.
        /// </summary>
        byte[] Content { get; set; }

        /// <summary>
        /// Converts the IFileResponse to a FileContentResult object for ASP.NET Core.
        /// </summary>
        /// <returns>A FileContentResult containing the file content.</returns>
        FileContentResult ToFile();
    }
}

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// This interface provides properties for user agent information, such as the remote IP address, operating system,
    /// browser, device type, and brand of the device.
    /// </summary>
    public interface IUserAgentResponse
    {
        /// <summary>
        /// Gets or sets the remote IP address of the client.
        /// </summary>
        string RemoteIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the operating system of the client.
        /// </summary>
        string OS { get; set; }

        /// <summary>
        /// Gets or sets the version of the operating system of the client.
        /// </summary>
        string VersionOS { get; set; }

        /// <summary>
        /// Gets or sets the browser of the client.
        /// </summary>
        string Browser { get; set; }

        /// <summary>
        /// Gets or sets the version of the browser of the client.
        /// </summary>
        string VersionBrowser { get; set; }

        /// <summary>
        /// Gets or sets the device type of the client.
        /// </summary>
        string Device { get; set; }

        /// <summary>
        /// Gets or sets the brand of the device of the client.
        /// </summary>
        string BrandDevice { get; set; }
    }

}

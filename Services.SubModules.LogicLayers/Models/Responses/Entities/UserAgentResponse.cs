namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// This class implements the IUserAgentResponse interface and provides properties for user agent information,
    /// such as the remote IP address, operating system, browser, device type, and brand of the device.
    /// </summary>
    public class UserAgentResponse : IUserAgentResponse
    {
        /// <summary>
        /// Gets or sets the remote IP address of the client.
        /// </summary>
        public string? RemoteIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the operating system of the client.
        /// </summary>
        public string? OS { get; set; }

        /// <summary>
        /// Gets or sets the version of the operating system of the client.
        /// </summary>
        public string? VersionOS { get; set; }

        /// <summary>
        /// Gets or sets the browser of the client.
        /// </summary>
        public string? Browser { get; set; }

        /// <summary>
        /// Gets or sets the version of the browser of the client.
        /// </summary>
        public string? VersionBrowser { get; set; }

        /// <summary>
        /// Gets or sets the device type of the client.
        /// </summary>
        public string? Device { get; set; }

        /// <summary>
        /// Gets or sets the brand of the device of the client.
        /// </summary>
        public string? BrandDevice { get; set; }
    }

}

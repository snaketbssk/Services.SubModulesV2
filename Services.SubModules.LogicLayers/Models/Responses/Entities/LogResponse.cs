﻿using Services.SubModules.LogicLayers.Models.Exceptions;
using System.Text;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    /// <summary>
    /// Represents a response containing log information.
    /// </summary>
    public class LogResponse : ILogResponse
    {
        /// <summary>
        /// Gets or sets the service associated with the log.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the log.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the status of the service exception.
        /// </summary>
        public StatusServiceException Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the log.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        public string MessageException { get; set; }

        /// <summary>
        /// Gets or sets the path associated with the log.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method associated with the log.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the stack trace of the log.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogResponse"/> class.
        /// </summary>
        public LogResponse(string service, DateTime timestamp, StatusServiceException status, Guid guid, string messageException, string path, string method, string stackTrace)
        {
            Service = service;
            Timestamp = timestamp.ToString();
            Guid = guid.ToString();
            MessageException = messageException;
            Path = path;
            Method = method;
            StackTrace = stackTrace;
            Status = status;
        }

        /// <summary>
        /// Returns a string representation of the log.
        /// </summary>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine();
            // Service
            result.Append("Service: ");
            result.AppendLine(Service);
            // Timestamp
            result.Append("Timestamp: ");
            result.AppendLine(Timestamp);
            // Status
            result.Append("Status: ");
            result.AppendLine($"{Status}");
            // Guid
            result.Append("Guid: ");
            result.AppendLine(Guid);
            // Method
            result.Append("Method: ");
            result.AppendLine(Method);
            // Path
            result.Append("Path: ");
            result.AppendLine(Path);
            // Message
            result.Append("Message: ");
            result.AppendLine(MessageException);
            // StackTrace
            result.Append("StackTrace: ");
            result.AppendLine(StackTrace);
            // Result
            return result.ToString();
        }
    }
}

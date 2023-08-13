using Microsoft.Data.SqlClient;
using Services.SubModules.DataLayers.Models.Requests.Entities;

namespace Services.SubModules.DataLayers.Models.Requests
{
    /// <summary>
    /// Represents an SQL query request interface with parameters.
    /// </summary>
    public interface ISqlRequest
    {
        /// <summary>
        /// Gets or sets the SQL query.
        /// </summary>
        string Sql { get; set; }

        /// <summary>
        /// Gets or sets the list of parameters for the SQL query.
        /// </summary>
        List<ParameterSqlRequest> Parameters { get; set; }

        /// <summary>
        /// Gets an array of <see cref="SqlParameter"/> objects based on the list of parameters.
        /// </summary>
        /// <returns>An array of <see cref="SqlParameter"/> objects.</returns>
        SqlParameter[] GetParameters();
    }
}

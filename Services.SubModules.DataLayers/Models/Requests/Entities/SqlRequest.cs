using Microsoft.Data.SqlClient;

namespace Services.SubModules.DataLayers.Models.Requests.Entities
{
    /// <summary>
    /// Represents an SQL query request with parameters.
    /// </summary>
    public class SqlRequest : ISqlRequest
    {
        /// <summary>
        /// Gets or sets the SQL query.
        /// </summary>
        public string Sql { get; set; }

        /// <summary>
        /// Gets or sets the list of parameters for the SQL query.
        /// </summary>
        public List<ParameterSqlRequest> Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlRequest"/> class with the specified SQL query and parameters.
        /// </summary>
        /// <param name="sql">The SQL query.</param>
        /// <param name="parameters">The list of parameters for the SQL query.</param>
        public SqlRequest(string sql, List<ParameterSqlRequest> parameters)
        {
            Sql = sql;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets an array of <see cref="SqlParameter"/> objects based on the list of parameters.
        /// </summary>
        /// <returns>An array of <see cref="SqlParameter"/> objects.</returns>
        public SqlParameter[] GetParameters()
        {
            if (Parameters is null || !Parameters.Any())
                return new SqlParameter[0];

            // Convert the list of ParameterSqlRequest objects to SqlParameter objects.
            var result = Parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();

            return result;
        }
    }
}

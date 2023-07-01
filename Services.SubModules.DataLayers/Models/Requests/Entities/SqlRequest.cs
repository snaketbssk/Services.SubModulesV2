using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.DataLayers.Models.Requests.Entities
{
    public class SqlRequest : ISqlRequest
    {
        public string Sql { get; set; }

        public List<ParameterSqlRequest> Parameters { get; set; }

        public SqlRequest(string sql, List<ParameterSqlRequest> parameters)
        {
            Sql = sql;
            Parameters = parameters;
        }

        public SqlParameter[] GetParameters()
        {
            if (Parameters is null || !Parameters.Any())
                return new SqlParameter[0];

            var result = Parameters.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
            return result;
        }
    }
}

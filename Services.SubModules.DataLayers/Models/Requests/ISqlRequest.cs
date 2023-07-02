using Microsoft.Data.SqlClient;
using Services.SubModules.DataLayers.Models.Requests.Entities;

namespace Services.SubModules.DataLayers.Models.Requests
{
    public interface ISqlRequest
    {
        string Sql { get; set; }

        List<ParameterSqlRequest> Parameters { get; set; }

        SqlParameter[] GetParameters();
    }
}

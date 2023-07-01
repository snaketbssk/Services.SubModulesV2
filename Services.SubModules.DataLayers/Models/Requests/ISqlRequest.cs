using Microsoft.Data.SqlClient;
using Services.SubModules.DataLayers.Models.Requests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.DataLayers.Models.Requests
{
    public interface ISqlRequest
    {
        string Sql { get; set; }

        List<ParameterSqlRequest> Parameters { get; set; }

        SqlParameter[] GetParameters();
    }
}

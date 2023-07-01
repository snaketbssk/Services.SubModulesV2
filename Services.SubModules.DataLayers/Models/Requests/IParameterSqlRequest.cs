using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.DataLayers.Models.Requests
{
    public interface IParameterSqlRequest
    {
        string Key { get; set; }
        object Value { get; set; }
    }
}

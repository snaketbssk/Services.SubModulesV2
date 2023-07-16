using Services.SubModules.DataLayers.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    public interface ILanguageResponse : IBaseTable<Guid>
    {
        string? Name { get; set; }
    }
}

using Services.SubModules.DataLayers.Models.Tables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses.Entities
{
    public class LanguageResponse : BaseTable<Guid>, ILanguageResponse
    {
        public string? Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.DataLayers.Models.Tables
{
    public interface IIdUserTable<T>
    {
        T IdUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Responses
{
    /// <summary>
    /// Represents a response object for an item chart with a generic data type.
    /// </summary>
    /// <typeparam name="T">The type of data in the chart.</typeparam>
    public interface IItemChartResponse<T>
    {
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the data points for the chart.
        /// </summary>
        List<T> Data { get; set; }
    }
}

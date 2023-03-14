using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Exceptions.Entities
{
    public class ServiceException : Exception
    {
        public StatusServiceException Status { get; set; }

        public ServiceException(StatusServiceException status, string? message = default) : base(message)
        {
            Status = status;
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IActionLoggerService
    {
        void ActionSuccess<T>(ILogger<T> _logger, string subject, string content);
    }
}

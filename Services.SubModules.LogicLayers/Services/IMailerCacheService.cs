using Services.SubModules.LogicLayers.Models.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services
{
    public interface IMailerCacheService
    {
        IValueRepositoryCache<bool> Outgoing { get; }
    }
}

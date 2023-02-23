using Services.SubModules.LogicLayers.Models.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public abstract class BaseMailerCacheService : IMailerCacheService
    {
        public IValueRepositoryCache<bool> Outgoing { get; private set; }

        protected BaseMailerCacheService(IValueRepositoryCache<bool> outgoing)
        {
            Outgoing = outgoing;
        }
    }
}

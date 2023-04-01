﻿using Services.SubModules.LogicLayers.Models.Cache;
using Services.SubModules.LogicLayers.Models.Cache.Entities;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class MailerCacheService : IMailerCacheService
    {
        public IOneValueRepositoryCache<bool> Outgoing { get; private set; }

        public MailerCacheService(ICacheService cacheService)
        {
            Outgoing = new OneValueRepositoryCache<bool>(cacheService,
                                                      nameof(MailerCacheService),
                                                      nameof(Outgoing),
                                                      TimeSpan.FromMinutes(1));
        }
    }
}

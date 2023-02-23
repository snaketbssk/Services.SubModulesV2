﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache
{
    public interface IRepositoryCache
    {
        string Project { get; }
        string Container { get; }
        TimeSpan? Expiry { get; }
    }
}

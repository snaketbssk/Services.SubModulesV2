﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Cache.Entities
{
    public class ValueCache<TValue> : IValuesCache<TValue>
    {
        public bool IsSuccessful { get; set; }
        public TValue Value { get; set; }

        public ValueCache()
        {
        }

        public ValueCache(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        public ValueCache(bool isSuccessful, TValue value) : this(isSuccessful)
        {
            Value = value;
        }
    }
}

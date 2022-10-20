﻿namespace Services.SubModules.LogicLayers.Models.Requests.Entities
{
    public class NameRequest : INameRequest
    {
        public string Name { get; set; }

        public NameRequest()
        {
        }

        public NameRequest(string name)
        {
            Name = name;
        }
    }
}

using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MediaFilesGrpcRequestMapping : Mapping<MediaFilesGrpcRequest>
    {
        public string Type { get; set; }
        public string Address { get; set; }
        public object Data { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public MediaFilesGrpcRequestMapping(
            string type,
            string address,
            object data,
            string language,
            DateTime date)
        { // 1
            Type = type;
            Address = address;
            Data = data;
            Language = language;
            Date = date;
        }
        public override MediaFilesGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MessageMailerGrpcRequest
            {
                Type = Type ?? "",
                Address = Address ?? "",
                Data = data ?? "",
                Date = Date.Ticks,
                Language = Language ?? ""
            };
            return result;
        }

        public override MediaFilesGrpcRequest Update(MediaFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

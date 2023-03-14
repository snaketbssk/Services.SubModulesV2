using Services.SubModules.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MediaImagesGrpcRequestMapping : Mapping<MediaImagesGrpcRequest>
    {
        public string Type { get; set; }
        public object Data { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public List<string> Images { get; set; }
        public MediaImagesGrpcRequestMapping(
            List<string> images,
            string type,
            object data,
            string language,
            DateTime date)
        {
            Images = images;
            Type = type;
            Data = data;
            Language = language;
            Date = date;
        }
        public override MediaImagesGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MediaImagesGrpcRequest
            {
                Message = new MessageTelegramGrpcRequest
                {
                    Type = Type ?? "",
                    Data = data ?? "",
                    Date = Date.Ticks,
                    Language = Language ?? ""
                }
            };
            result.Images.AddRange(Images.Select(x => new MessageImageGrpcRequest
            {
                Name = x
            }));

            return result;
        }

        public override MediaImagesGrpcRequest Update(MediaImagesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

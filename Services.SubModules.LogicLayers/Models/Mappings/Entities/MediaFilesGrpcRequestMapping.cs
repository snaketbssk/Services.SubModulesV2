using Google.Protobuf;
using Services.SubModules.Protos;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Models.Mappings.Entities
{
    public class MediaFilesGrpcRequestMapping : Mapping<MediaFilesGrpcRequest>
    {
        public string Type { get; set; }
        public object Data { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public List<byte[]> Files { get; set; }
        public MediaFilesGrpcRequestMapping(
            List<byte[]> files,
            string type,
            object data,
            string language,
            DateTime date)
        {
            Files = files;
            Type = type;
            Data = data;
            Language = language;
            Date = date;
        }
        public override MediaFilesGrpcRequest Map()
        {
            var data = JsonSerializer.Serialize(Data);
            var result = new MediaFilesGrpcRequest
            {
                Message = new MessageTelegramGrpcRequest
                {
                    Type = Type ?? "",
                    Data = data ?? "",
                    Date = Date.Ticks,
                    Language = Language ?? ""
                }
            };
            result.Files.AddRange(Files.Select(x => new MessageFileGrpcRequest
            {
                Name = "1.webp",
                Content = ByteString.CopyFrom(x)
            }));
            return result;
        }

        public override MediaFilesGrpcRequest Update(MediaFilesGrpcRequest result)
        {
            throw new NotImplementedException();
        }
    }
}

using NapCat.OneBot.NET.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NapCat.OneBot.NET
{
    public static class JsonHelper
    {
        public static T? GetData<T>(this JsonElement element)
        {
            return element.Deserialize<T>(new JsonSerializerOptions
            {
                Converters = {
                new MessageJsonConverter()
            }
            });
        }
    }

    public class MessageJsonConverter : JsonConverter<IMessage>
    {
        public override IMessage? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
            var type = jsonObject.GetProperty("type").GetString();
            switch (type)
            {
                case "text":
                    return JsonSerializer.Deserialize<PlainMessage>(jsonObject.GetRawText());
                case "image":
                    return JsonSerializer.Deserialize<ImageMessage>(jsonObject.GetRawText());
                case "reply":
                    return JsonSerializer.Deserialize<ReplyMessage>(jsonObject.GetRawText());
                case "at":
                    return JsonSerializer.Deserialize<AtMessage>(jsonObject.GetRawText());
                case "face":
                    return JsonSerializer.Deserialize<FaceMessage>(jsonObject.GetRawText());
                case "record":
                    return JsonSerializer.Deserialize<RecordMessage>(jsonObject.GetRawText());
                case "video":
                    return JsonSerializer.Deserialize<VideoMessage>(jsonObject.GetRawText());
                case "rps":
                    return JsonSerializer.Deserialize<RpsMessage>(jsonObject.GetRawText());
                case "dice":
                    return JsonSerializer.Deserialize<DiceMessage>(jsonObject.GetRawText());
                case "shake":
                    return JsonSerializer.Deserialize<ShakeMessage>(jsonObject.GetRawText());
                case "poke":
                    return JsonSerializer.Deserialize<PokeMessage>(jsonObject.GetRawText());
                case "anonymous":
                    return JsonSerializer.Deserialize<AnonymousMessage>(jsonObject.GetRawText());
                case "share":
                    return JsonSerializer.Deserialize<ShareMessage>(jsonObject.GetRawText());
                case "contact":
                    return JsonSerializer.Deserialize<ContactMessage>(jsonObject.GetRawText());
                case "location":
                    return JsonSerializer.Deserialize<LocationMessage>(jsonObject.GetRawText());
                case "music":
                    // Check if it's a custom music message
                    if (jsonObject.GetProperty("data").TryGetProperty("type", out var musicType) && 
                        musicType.GetString() == "custom")
                    {
                        return JsonSerializer.Deserialize<CustomMusicMessage>(jsonObject.GetRawText());
                    }
                    return JsonSerializer.Deserialize<MusicMessage>(jsonObject.GetRawText());
                case "forward":
                    return JsonSerializer.Deserialize<ForwardMessage>(jsonObject.GetRawText());
                case "node":
                    // Check if it has user_id property to determine if it's a custom node
                    if (jsonObject.GetProperty("data").TryGetProperty("user_id", out _))
                    {
                        return JsonSerializer.Deserialize<CustomNodeMessage>(jsonObject.GetRawText());
                    }
                    return JsonSerializer.Deserialize<NodeMessage>(jsonObject.GetRawText());
                case "xml":
                    return JsonSerializer.Deserialize<XmlMessage>(jsonObject.GetRawText());
                case "json":
                    return JsonSerializer.Deserialize<JsonMessage>(jsonObject.GetRawText());
                default:
                    return new SimpleMessage();
            }
        }

        public override void Write(Utf8JsonWriter writer, IMessage value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType());

        }
    }
}

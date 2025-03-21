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
                default:
                    return new SimpleMessage();
            }
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, IMessage value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType());

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NapCat.OneBot.NET.Messages
{
    public enum SendMessageType
    {
        Group,
        Friend,
        Temp
    }

    public interface IMessage
    {
        [JsonPropertyName("type")]
        string Type { get; }
        [JsonPropertyName("data")]
        object Data { get; }
    }
    public class AtMessage(string qq) : IMessage
    {
        [JsonPropertyName("text")]
        public string Type { get; } = "at";
        [JsonPropertyName("data")]
        public object Data { get; } = new { qq };
    }
    public class PlainMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "text";

        [JsonPropertyName("data")]
        public object Data { get; }
        public PlainMessage()
        {
            
        }
        public PlainMessage(string text)
        {
            Data = new { text };
        }
    }

    public class FaceMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "face";

        [JsonPropertyName("data")]
        public object Data { get; }

        public FaceMessage(string id)
        {
            Data = new { id };
        }
    }

    public class ImageMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "image";

        [JsonPropertyName("data")]
        public object Data { get; }

        public ImageMessage(string file, string type = null, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new { file, type, url, cache, proxy, timeout };
        }
    }

    public class RecordMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "record";

        [JsonPropertyName("data")]
        public object Data { get; }

        public RecordMessage(string file, int magic = 0, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new { file, magic, url, cache, proxy, timeout };
        }
    }

    public class VideoMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "video";

        [JsonPropertyName("data")]
        public object Data { get; }

        public VideoMessage(string file, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new { file, url, cache, proxy, timeout };
        }
    }

    public class RpsMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "rps";

        [JsonPropertyName("data")]
        public object Data { get; } = new { };
    }

    public class DiceMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "dice";

        [JsonPropertyName("data")]
        public object Data { get; } = new { };
    }

    public class ShakeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "shake";

        [JsonPropertyName("data")]
        public object Data { get; } = new { };
    }

    public class PokeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "poke";

        [JsonPropertyName("data")]
        public object Data { get; }

        public PokeMessage(string type, string id)
        {
            Data = new { type, id };
        }
    }

    public class AnonymousMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "anonymous";

        [JsonPropertyName("data")]
        public object Data { get; } = new { };
    }

    public class ShareMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "share";

        [JsonPropertyName("data")]
        public object Data { get; }

        public ShareMessage(string url, string title, string content = null, string image = null)
        {
            Data = new { url, title, content, image };
        }
    }

    public class ContactMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "contact";

        [JsonPropertyName("data")]
        public object Data { get; }

        public ContactMessage(string type, string id)
        {
            Data = new { type, id };
        }
    }

    public class LocationMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "location";

        [JsonPropertyName("data")]
        public object Data { get; }

        public LocationMessage(string lat, string lon, string title = null, string content = null)
        {
            Data = new { lat, lon, title, content };
        }
    }

    public class MusicMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "music";

        [JsonPropertyName("data")]
        public object Data { get; }

        public MusicMessage(string type, string id)
        {
            Data = new { type, id };
        }
    }

    public class CustomMusicMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "music";

        [JsonPropertyName("data")]
        public object Data { get; }

        public CustomMusicMessage(string url, string audio, string title, string content = null, string image = null)
        {
            Data = new { type = "custom", url, audio, title, content, image };
        }
    }

    public class ReplyMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "reply";

        [JsonPropertyName("data")]
        public object Data { get; }

        public ReplyMessage(string id)
        {
            Data = new { id };
        }
    }

    public class ForwardMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "forward";

        [JsonPropertyName("data")]
        public object Data { get; }

        public ForwardMessage(string id)
        {
            Data = new { id };
        }
    }

    public class NodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "node";

        [JsonPropertyName("data")]
        public object Data { get; }

        public NodeMessage(string id)
        {
            Data = new { id };
        }
    }

    public class CustomNodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "node";

        [JsonPropertyName("data")]
        public object Data { get; }

        public CustomNodeMessage(string userId, string nickname, object content)
        {
            Data = new { user_id = userId, nickname, content };
        }
    }

    public class XmlMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "xml";

        [JsonPropertyName("data")]
        public object Data { get; }

        public XmlMessage(string data)
        {
            Data = new { data };
        }
    }

    public class JsonMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "json";

        [JsonPropertyName("data")]
        public object Data { get; }

        public JsonMessage(string data)
        {
            Data = new { data };
        }
    }
}

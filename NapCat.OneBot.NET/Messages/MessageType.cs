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
    }

    #region Data Classes
    public class AtMessageData
    {
        public string qq { get; set; }
        
        public AtMessageData(string qq)
        {
            this.qq = qq;
        }
    }

    public class PlainMessageData
    {
        public string text { get; set; }
        
        public PlainMessageData() { }
        
        public PlainMessageData(string text)
        {
            this.text = text;
        }
    }

    public class FaceMessageData
    {
        public string id { get; set; }
        
        public FaceMessageData(string id)
        {
            this.id = id;
        }
    }

    public class ImageMessageData
    {
        public string file { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public int cache { get; set; }
        public int proxy { get; set; }
        public int timeout { get; set; }
        
        public ImageMessageData(string file, string type = null, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            this.file = file;
            this.type = type;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }
    }

    public class RecordMessageData
    {
        public string file { get; set; }
        public int magic { get; set; }
        public string url { get; set; }
        public int cache { get; set; }
        public int proxy { get; set; }
        public int timeout { get; set; }
        
        public RecordMessageData(string file, int magic = 0, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            this.file = file;
            this.magic = magic;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }
    }

    public class VideoMessageData
    {
        public string file { get; set; }
        public string url { get; set; }
        public int cache { get; set; }
        public int proxy { get; set; }
        public int timeout { get; set; }
        
        public VideoMessageData(string file, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            this.file = file;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }
    }

    public class EmptyData
    {
    }

    public class PokeMessageData
    {
        public string type { get; set; }
        public string id { get; set; }
        
        public PokeMessageData(string type, string id)
        {
            this.type = type;
            this.id = id;
        }
    }

    public class ShareMessageData
    {
        public string url { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        
        public ShareMessageData(string url, string title, string content = null, string image = null)
        {
            this.url = url;
            this.title = title;
            this.content = content;
            this.image = image;
        }
    }

    public class ContactMessageData
    {
        public string type { get; set; }
        public string id { get; set; }
        
        public ContactMessageData(string type, string id)
        {
            this.type = type;
            this.id = id;
        }
    }

    public class LocationMessageData
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        
        public LocationMessageData(string lat, string lon, string title = null, string content = null)
        {
            this.lat = lat;
            this.lon = lon;
            this.title = title;
            this.content = content;
        }
    }

    public class MusicMessageData
    {
        public string type { get; set; }
        public string id { get; set; }
        
        public MusicMessageData(string type, string id)
        {
            this.type = type;
            this.id = id;
        }
    }

    public class CustomMusicMessageData
    {
        public string type { get; set; } = "custom";
        public string url { get; set; }
        public string audio { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        
        public CustomMusicMessageData(string url, string audio, string title, string content = null, string image = null)
        {
            this.url = url;
            this.audio = audio;
            this.title = title;
            this.content = content;
            this.image = image;
        }
    }

    public class ReplyMessageData
    {
        public string id { get; set; }
        
        public ReplyMessageData(string id)
        {
            this.id = id;
        }
    }

    public class ForwardMessageData
    {
        public string id { get; set; }
        
        public ForwardMessageData(string id)
        {
            this.id = id;
        }
    }

    public class NodeMessageData
    {
        public string id { get; set; }
        
        public NodeMessageData(string id)
        {
            this.id = id;
        }
    }

    public class CustomNodeMessageData
    {
        [JsonPropertyName("user_id")]
        public string userId { get; set; }
        public string nickname { get; set; }
        public object content { get; set; }
        
        public CustomNodeMessageData(string userId, string nickname, object content)
        {
            this.userId = userId;
            this.nickname = nickname;
            this.content = content;
        }
    }

    public class XmlMessageData
    {
        public string data { get; set; }
        
        public XmlMessageData(string data)
        {
            this.data = data;
        }
    }

    public class JsonMessageData
    {
        public string data { get; set; }
        
        public JsonMessageData(string data)
        {
            this.data = data;
        }
    }
    #endregion

    public class AtMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "at";
        [JsonPropertyName("data")]
        public AtMessageData Data { get; }
        
        public AtMessage(string qq)
        {
            Data = new AtMessageData(qq);
        }
    }
    
    public class PlainMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "text";

        [JsonPropertyName("data")]
        public PlainMessageData Data { get; }
        
        public PlainMessage()
        {
            Data = new PlainMessageData();
        }
        
        public PlainMessage(string text)
        {
            Data = new PlainMessageData(text);
        }
    }

    public class FaceMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "face";

        [JsonPropertyName("data")]
        public FaceMessageData Data { get; }

        public FaceMessage(string id)
        {
            Data = new FaceMessageData(id);
        }
    }

    public class ImageMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "image";

        [JsonPropertyName("data")]
        public ImageMessageData Data { get; }

        public ImageMessage(string file, string type = null, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new ImageMessageData(file, type, url, cache, proxy, timeout);
        }
    }

    public class RecordMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "record";

        [JsonPropertyName("data")]
        public RecordMessageData Data { get; }

        public RecordMessage(string file, int magic = 0, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new RecordMessageData(file, magic, url, cache, proxy, timeout);
        }
    }

    public class VideoMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "video";

        [JsonPropertyName("data")]
        public VideoMessageData Data { get; }

        public VideoMessage(string file, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new VideoMessageData(file, url, cache, proxy, timeout);
        }
    }

    public class RpsMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "rps";

        [JsonPropertyName("data")]
        public EmptyData Data { get; } = new EmptyData();
    }

    public class DiceMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "dice";

        [JsonPropertyName("data")]
        public EmptyData Data { get; } = new EmptyData();
    }

    public class ShakeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "shake";

        [JsonPropertyName("data")]
        public EmptyData Data { get; } = new EmptyData();
    }

    public class PokeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "poke";

        [JsonPropertyName("data")]
        public PokeMessageData Data { get; }

        public PokeMessage(string type, string id)
        {
            Data = new PokeMessageData(type, id);
        }
    }

    public class AnonymousMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "anonymous";

        [JsonPropertyName("data")]
        public EmptyData Data { get; } = new EmptyData();
    }

    public class ShareMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "share";

        [JsonPropertyName("data")]
        public ShareMessageData Data { get; }

        public ShareMessage(string url, string title, string content = null, string image = null)
        {
            Data = new ShareMessageData(url, title, content, image);
        }
    }

    public class ContactMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "contact";

        [JsonPropertyName("data")]
        public ContactMessageData Data { get; }

        public ContactMessage(string type, string id)
        {
            Data = new ContactMessageData(type, id);
        }
    }

    public class LocationMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "location";

        [JsonPropertyName("data")]
        public LocationMessageData Data { get; }

        public LocationMessage(string lat, string lon, string title = null, string content = null)
        {
            Data = new LocationMessageData(lat, lon, title, content);
        }
    }

    public class MusicMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "music";

        [JsonPropertyName("data")]
        public MusicMessageData Data { get; }

        public MusicMessage(string type, string id)
        {
            Data = new MusicMessageData(type, id);
        }
    }

    public class CustomMusicMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "music";

        [JsonPropertyName("data")]
        public CustomMusicMessageData Data { get; }

        public CustomMusicMessage(string url, string audio, string title, string content = null, string image = null)
        {
            Data = new CustomMusicMessageData(url, audio, title, content, image);
        }
    }

    public class ReplyMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "reply";

        [JsonPropertyName("data")]
        public ReplyMessageData Data { get; }

        public ReplyMessage(string id)
        {
            Data = new ReplyMessageData(id);
        }
    }

    public class ForwardMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "forward";

        [JsonPropertyName("data")]
        public ForwardMessageData Data { get; }

        public ForwardMessage(string id)
        {
            Data = new ForwardMessageData(id);
        }
    }

    public class NodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "node";

        [JsonPropertyName("data")]
        public NodeMessageData Data { get; }

        public NodeMessage(string id)
        {
            Data = new NodeMessageData(id);
        }
    }

    public class CustomNodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "node";

        [JsonPropertyName("data")]
        public CustomNodeMessageData Data { get; }

        public CustomNodeMessage(string userId, string nickname, object content)
        {
            Data = new CustomNodeMessageData(userId, nickname, content);
        }
    }

    public class XmlMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "xml";

        [JsonPropertyName("data")]
        public XmlMessageData Data { get; }

        public XmlMessage(string data)
        {
            Data = new XmlMessageData(data);
        }
    }

    public class JsonMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; } = "json";

        [JsonPropertyName("data")]
        public JsonMessageData Data { get; }

        public JsonMessage(string data)
        {
            Data = new JsonMessageData(data);
        }
    }
}

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

    public class SimpleMessage: IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "message";
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
            if (File.Exists(file))
            this.file = "file:///" + file;
            else
                this.file =  file;

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
        public string Type { get; set; } = "at";
        [JsonPropertyName("data")]
        public AtMessageData Data { get; set; }
        
        public AtMessage(string qq)
        {
            Data = new AtMessageData(qq);
        }
    }
    
    public class PlainMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "text";

        [JsonPropertyName("data")]
        public PlainMessageData Data { get; set; }
        
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
        public string Type { get; set; } = "face";

        [JsonPropertyName("data")]
        public FaceMessageData Data { get; set; }
        public FaceMessage()
        {
            
        }
        public FaceMessage(string id)
        {
            Data = new FaceMessageData(id);
        }
    }

    public class ImageMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "image";

        [JsonPropertyName("data")]
        public ImageMessageData Data { get; set; }
        public ImageMessage()
        {
            
        }
        public ImageMessage(string file, string type = null, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new ImageMessageData(file, type, url, cache, proxy, timeout);
        }
    }

    public class RecordMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "record";

        [JsonPropertyName("data")]
        public RecordMessageData Data { get; set; }
        public RecordMessage()
        {
            
        }
        public RecordMessage(string file, int magic = 0, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new RecordMessageData(file, magic, url, cache, proxy, timeout);
        }
    }

    public class VideoMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "video";

        [JsonPropertyName("data")]
        public VideoMessageData Data { get; set; }
        public VideoMessage()
        {
            
        }
        public VideoMessage(string file, string url = null, int cache = 1, int proxy = 1, int timeout = 0)
        {
            Data = new VideoMessageData(file, url, cache, proxy, timeout);
        }
    }

    public class RpsMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "rps";

        [JsonPropertyName("data")]
        public EmptyData Data { get; set; } = new EmptyData();
        public RpsMessage()
        {
            
        }
    }

    public class DiceMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "dice";

        [JsonPropertyName("data")]
        public EmptyData Data { get; set; } = new EmptyData();
        public DiceMessage()
        {
            
        }
    }

    public class ShakeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "shake";

        [JsonPropertyName("data")]
        public EmptyData Data { get; set; } = new EmptyData();
        public ShakeMessage()
        {
            
        }
    }

    public class PokeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "poke";

        [JsonPropertyName("data")]
        public PokeMessageData Data { get; set; }

        public PokeMessage(string type, string id)
        {
            Data = new PokeMessageData(type, id);
        }
        public PokeMessage()
        {
            
        }
    }

    public class AnonymousMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "anonymous";

        [JsonPropertyName("data")]
        public EmptyData Data { get; set; } = new EmptyData();
        public AnonymousMessage()
        {
            
        }
    }

    public class ShareMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "share";

        [JsonPropertyName("data")]
        public ShareMessageData Data { get; set; }
        public ShareMessage()
        {
            
        }

        public ShareMessage(string url, string title, string content = null, string image = null)
        {
            Data = new ShareMessageData(url, title, content, image);
        }
    }

    public class ContactMessage : IMessage
    {
        public ContactMessage()
        {
            
        }
        [JsonPropertyName("type")]
        public string Type { get; set; } = "contact";

        [JsonPropertyName("data")]
        public ContactMessageData Data { get; set; }

        public ContactMessage(string type, string id)
        {
            Data = new ContactMessageData(type, id);
        }
    }

    public class LocationMessage : IMessage
    {
        public LocationMessage()
        {
            
        }
        [JsonPropertyName("type")]
        public string Type { get; set; } = "location";

        [JsonPropertyName("data")]
        public LocationMessageData Data { get; set; }

        public LocationMessage(string lat, string lon, string title = null, string content = null)
        {
            Data = new LocationMessageData(lat, lon, title, content);
        }
    }

    public class MusicMessage : IMessage
    {
        public MusicMessage()
        {
            
        }
        [JsonPropertyName("type")]
        public string Type { get; set; } = "music";

        [JsonPropertyName("data")]
        public MusicMessageData Data { get; set; }

        public MusicMessage(string type, string id)
        {
            Data = new MusicMessageData(type, id);
        }
    }

    public class CustomMusicMessage : IMessage
    {
        public CustomMusicMessage()
        {
            
        }
        [JsonPropertyName("type")]
        public string Type { get; set; } = "music";

        [JsonPropertyName("data")]
        public CustomMusicMessageData Data { get; set; }

        public CustomMusicMessage(string url, string audio, string title, string content = null, string image = null)
        {
            Data = new CustomMusicMessageData(url, audio, title, content, image);
        }
    }

    public class ReplyMessage : IMessage
    {
       
        [JsonPropertyName("type")]
        public string Type { get; set; } = "reply";

        [JsonPropertyName("data")]
        public ReplyMessageData Data { get; set; }
        public ReplyMessage()
        {
            
        }
        public ReplyMessage(string id)
        {
            Data = new ReplyMessageData(id);
        }
    }

    public class ForwardMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "forward";

        [JsonPropertyName("data")]
        public ForwardMessageData Data { get; set; }
        public ForwardMessage()
        {
            
        }
        public ForwardMessage(string id)
        {
            Data = new ForwardMessageData(id);
        }
    }

    public class NodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "node";

        [JsonPropertyName("data")]
        public NodeMessageData Data { get; set; }
        public NodeMessage()
        {
            
        }
        public NodeMessage(string id)
        {
            Data = new NodeMessageData(id);
        }
    }

    public class CustomNodeMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "node";

        [JsonPropertyName("data")]
        public CustomNodeMessageData Data { get; set; }
        public CustomNodeMessage()
        {
            
        }
        public CustomNodeMessage(string userId, string nickname, object content)
        {
            Data = new CustomNodeMessageData(userId, nickname, content);
        }
    }

    public class XmlMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "xml";

        [JsonPropertyName("data")]
        public XmlMessageData Data { get; set; }
        public XmlMessage()
        {
            
        }
        public XmlMessage(string data)
        {
            Data = new XmlMessageData(data);
        }
    }

    public class JsonMessage : IMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "json";

        [JsonPropertyName("data")]
        public JsonMessageData Data { get; set; }
        public JsonMessage()
        {
            
        }
        public JsonMessage(string data)
        {
            Data = new JsonMessageData(data);
        }
    }
}

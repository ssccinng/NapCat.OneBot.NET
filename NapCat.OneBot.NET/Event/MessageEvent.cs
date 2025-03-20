using NapCat.OneBot.NET.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NapCat.OneBot.NET.Event
{
    public class MessageEvent
    {
        [JsonPropertyName("time")]
        public long Time { get; set; } // 事件发生的时间戳

        [JsonPropertyName("self_id")]
        public long SelfId { get; set; } // 收到事件的机器人 QQ 号

        [JsonPropertyName("post_type")]
        public string PostType { get; set; } = string.Empty;// 上报类型

        [JsonPropertyName("message_type")]
        public string? MessageType { get; set; } // 消息类型

        [JsonPropertyName("sub_type")]
        public string? SubType { get; set; } // 消息子类型

        [JsonPropertyName("message_id")]
        public int MessageId { get; set; } // 消息 ID

        [JsonPropertyName("user_id")]
        public long UserId { get; set; } // 发送者 QQ 号


        [JsonPropertyName("group_id")]
        public long? GroupId { get; set; } // 发送者 QQ 号

        [JsonPropertyName("message")]
        public IMessage[] Message { get; set; } = []; // 消息内容 

        [JsonPropertyName("raw_message")]
        public string RawMessage { get; set; } = string.Empty;  // 原始消息内容

        [JsonPropertyName("font")]
        public int Font { get; set; } // 字体

        [JsonPropertyName("sender")]
        public Sender Sender { get; set; } // 发送人信息

        [JsonPropertyName("anonymous")] // 群消息特有
        public object? Anonymous { get; set; }



    }

    public class Sender
    {
        [JsonPropertyName("user_id")]
        public long UserId { get; set; } // 发送者 QQ 号

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; } // 昵称

        [JsonPropertyName("sex")]
        public string Sex { get; set; } // 性别，male 或 female 或 unknown

        [JsonPropertyName("age")]
        public int Age { get; set; } // 年龄
    }
}

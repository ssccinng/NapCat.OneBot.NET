using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NapCat.OneBot.NET.Event
{
    public class MetaEvent
    {
        [JsonPropertyName("time")]
        public long Time { get; set; } // 事件发生的时间戳

        [JsonPropertyName("self_id")]
        public long SelfId { get; set; } // 收到事件的机器人 QQ 号

        [JsonPropertyName("post_type")]
        public string PostType { get; set; } // 上报类型

        [JsonPropertyName("meta_event_type")]
        public string MetaEventType { get; set; } // 元事件类型

        [JsonPropertyName("sub_type")]
        public string SubType { get; set; } // 事件子类型，分别表示 OneBot 启用、停用、WebSocket 连接成功
        public enum SubTypeEnum
        {
            Enable,  // OneBot 启用
            Disable, // OneBot 停用
            Connect  // WebSocket 连接成功
        }
    }

}

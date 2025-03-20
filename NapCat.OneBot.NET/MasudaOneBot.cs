using Microsoft.Extensions.Caching.Memory;
using NapCat.OneBot.NET.Messages;
using System.Data;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using LanguageExt;
using static LanguageExt.Prelude;
using NapCat.OneBot.NET.Event;
using NapCat.OneBot.NET.Requests;
namespace NapCat.OneBot.NET
{
    public record BotConfig(string IPAddress, string Key);
    public class MasudaOneBot
    {
        public required BotConfig BotConfig { get; init; }
        private ClientWebSocket _client;
        private Thread _thread;


        #region 事件
        public event Action<MasudaOneBot, MessageEvent> OnMessage;
        public event Action<MasudaOneBot, MessageEvent> OnGroupMessage;
        public event Action<MasudaOneBot, MessageEvent> OnFriendMessage;
        #endregion

        MemoryCache memoryCache = new (new MemoryCacheOptions() { });


        public async Task LaunchAsync()
        {
            Uri uri = new Uri($"ws://{BotConfig.IPAddress}?access_token={BotConfig.Key}");
            _client = new ClientWebSocket();
            await _client.ConnectAsync(uri, CancellationToken.None);
            _thread = new Thread(async () => await Receive(_client));
            _thread.Start();
        }

        public object? GetMessage(JsonElement jsonElement)
        {
            if (jsonElement.TryGetProperty("post_type", out var pt))
            {
                return pt.GetString() switch
                {
                    "message" => jsonElement.GetData<MessageEvent>(),
                    "meta_event" => new object(),
                    "notice" =>  new object(),
                    "request" => new object(),
                    _ => throw new NotImplementedException()
                };
            }
            return null;
            throw new NotImplementedException(); 
        }

        internal async Task MessageHandlerAsync(string message)
        {

            System.Console.WriteLine(message);
            var jsondata = new Try<JsonElement>(() => JsonDocument.Parse(message).RootElement).Invoke().Map(GetMessage);
            // return;
            jsondata.Match(
                Succ: (data) =>
                {
                    switch (data)
                    {
                        case MessageEvent messageEvent:
                            OnMessage?.Invoke(this, messageEvent);
                            break;
                        default:
                            break;
                    }
                    return Unit.Default;
                },
                Fail: (ex) =>
                {
                    Console.WriteLine(ex.Message);
                    return Unit.Default;

                }

                );
            }
        

        async Task Send(ClientWebSocket client, string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        async Task Receive(ClientWebSocket client)
        {
            byte[] buffer = new byte[1024 * 1024];
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    sb.Append(message);
                    await MessageHandlerAsync(message);
                    //if (message.EndsWith("[end]"))
                    //{
                    //    sb.Remove(sb.Length - 5, 5);
                    //    message = sb.ToString();
                    //    sb.Clear();
                    //    await MessageHandlerAsync(message);
                    //}
                    // Console.WriteLine("Received: " + message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine("Connection closed.");
                    break;
                }
            }
        }



        #region MessageMethod
        public async Task SendFriendMessageAsync(long target, params IMessage[] message)
        {
            await SendMessageCoreAsync(target, SendMessageType.Friend, message);
        }

        public async Task SendGroupMessageAsync(long group, string message)
        {
            await SendGroupMessageAsync(group, new PlainMessage (message));
        }
        public async Task ReplyMessageAsync(MessageEvent masudaMessage, string message)
        {
            await ReplyMessageAsync(masudaMessage, new PlainMessage (message ));
        }
        public async Task ReplyMessageAsync(MessageEvent masudaMessage, params IMessage[] messages)
        {
            await SendMessageAsync(masudaMessage, messages.Prepend(new ReplyMessage(masudaMessage.MessageId.ToString())).ToArray());
        }
        public async Task SendMessageAsync(MessageEvent masudaMessage, string message)
        {
            if (masudaMessage.MessageType == "group")
            {
                await SendMessageCoreAsync(masudaMessage.GroupId!.Value, SendMessageType.Group, new PlainMessage(message));

            }
            else
            {
                await SendMessageCoreAsync(masudaMessage.UserId, SendMessageType.Friend, new PlainMessage(message));
            }
        }
        public async Task SendMessageAsync(MessageEvent masudaMessage, params IMessage[] messages)
        {
            if (masudaMessage.MessageType == "group")
            {
                await SendMessageCoreAsync(masudaMessage.GroupId!.Value, SendMessageType.Group, messages);

            }
            else
            {
                await SendMessageCoreAsync(masudaMessage.UserId, SendMessageType.Friend, messages);
            }
        }
        //public async Task SendMessageAsync(Sender peer, params IMessage[] messages)
        //{
        //    if (peer.ChatType == "group")
        //        await SendGroupMessageAsync(peer.UserId, messages);
        //    else if (peer.ChatType == "friend")
        //        await SendFriendMessageAsync(peer.UserId, messages);
        //}
        //public async Task SendMessageAsync(Sender peer, string message)
        //{
        //    if (peer.ChatType == "group")
        //        await SendGroupMessageAsync(peer.UserId, new PlainMessage(message));
        //    else if (peer.ChatType == "friend")
        //        await SendFriendMessageAsync(peer.UserId, new PlainMessage(message));
        //}
        public class te
        {
            public string action { get; set; }
            public string echo { get; set; }
            public object @params { get; set; }
        }
        private async Task SendRequestAsync(Request request)
        {
            var data = new te { action = request.Action, echo = "123", @params = request };
            var json = JsonSerializer.Serialize(data);
            await Send(_client, json);
        }

        private async Task SendMessageCoreAsync(long target, SendMessageType commandType, params IMessage[] message)
        {
            var req = commandType switch
            {
                SendMessageType.Group => new SendMsg { GroupId = target, Message = message, MessageType = "group" },

                SendMessageType.Friend => new SendMsg { UserId = target, Message = message, MessageType = "friend" },
                _ => throw new NotImplementedException()
            };

            await SendRequestAsync(req);

            //var data = JsonSerializer.Serialize(new
            //{
            //    CommandType = commandType,
            //    Data = new SendMessageComand
            //    {
            //        Target = target,
            //        MessageChain = message
            //    }
            //}, new JsonSerializerOptions
            //{
            //    Converters = { new MessageJsonConverter() },
            //    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            //});
            //await Send(_client, data);
        }
        public async Task SendGroupMessageAsync(long group, params IMessage[] message)
        {
            await SendMessageCoreAsync(group, SendMessageType.Group, message);
        }
        #endregion


        #region GetInfoMethod

        private static CancellationToken GetTimeToken()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(30000);
            return cancellationTokenSource.Token;
        }

       
        #endregion
    }
}

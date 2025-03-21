// See https://aka.ms/new-console-template for more information
using NapCat.OneBot.NET;
using NapCat.OneBot.NET.Messages;
using System.Net.WebSockets;
using System.Threading.Tasks;
//ClientWebSocket client = new ClientWebSocket();


//await client.ConnectAsync(new Uri("ws://localhost:3001/?access_token=123456"), CancellationToken.None);
////await client.ConnectAsync(new Uri("ws://127.0.0.1:3001/?access_token=123456"), CancellationToken.None);

//while (client.State == WebSocketState.Open)
//{
//    var buffer = new ArraySegment<byte>(new byte[1024]);
//    var result = await client.ReceiveAsync(buffer, CancellationToken.None);
//    var message = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
//    Console.WriteLine(message);
//}

MasudaOneBot masudaOneBot = new MasudaOneBot() { BotConfig = new BotConfig("localhost:3001/", "123456") };
masudaOneBot.OnMessage += MasudaOneBot_OnMessage;

async void MasudaOneBot_OnMessage(MasudaOneBot bot, NapCat.OneBot.NET.Event.MessageEvent msgs)
{
    if (msgs.GroupId != null && msgs.GroupId == 790890246)
    {
        Console.WriteLine($"GroupId: {msgs.GroupId}");
    }
    else
    {
        return;
    }
    foreach (var msg in msgs.Message)
    {
        switch (msg)
        {
            case PlainMessage plainMessage:
                Console.WriteLine(plainMessage.Data);
                await bot.ReplyMessageAsync(msgs, "dani");
                break;
            default:
                break;
        }
    }
}

await masudaOneBot.LaunchAsync();
Console.ReadLine();
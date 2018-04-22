using System.Threading.Tasks;
using Discord;
using System;
using Discord.WebSocket;
using Discord.Audio;

namespace WedgeBot
{
    class Program
    {
        public static void Main(string[] args)
                    => new Program().MainAsync().GetAwaiter().GetResult();

     
        public async Task MainAsync()
        {
            var client = new DiscordSocketClient();

            client.Log += Log;

            string totallySecureToken = "NDM1NjA5NjYyNzAwNjUwNDk3.DbbfqQ.ZF3ptkIVqj_JyiHwHKaIqQOuHc8";

            await client.LoginAsync(TokenType.Bot, totallySecureToken);

            client.MessageReceived += MessageReceived;


            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            var channel = ((Discord.WebSocket.SocketGuildUser)message.Author).VoiceChannel;
            IAudioClient client = await channel.ConnectAsync();

            //var authorVoiceChannel = client. //message.Author.Id
            if (message.Content == "!Wedge")
            {

                if (message.Author.Username == "Sik")
                {
                    await message.Channel.SendMessageAsync("Even you could do this, Sik");

                }

                else if (message.Author.Username == "Dm430")
                {
                    await message.Channel.SendMessageAsync("NO DEVIN, STAHP");

                }
                else
                {
                    await message.Channel.SendMessageAsync("Hi, I'm the best character in Star Wars!");
                }
                
            }

        }


        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

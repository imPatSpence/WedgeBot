using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WedgeBot.Modules
{

    public class SimpleReply : ModuleBase<SocketCommandContext>
    {
        [Command("sup")]
        public async Task SimpleReplyAsync ()
        {
            string wedgeSelfie = "https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Wedge_Antilles-Denis_Lawson-Star_Wars_%281977%29.jpg/220px-Wedge_Antilles-Denis_Lawson-Star_Wars_%281977%29.jpg";

            EmbedBuilder builder = new EmbedBuilder();
            builder.WithDescription("Hi, I'm the best character in Star Wars!")
                .WithColor(Color.Red).WithImageUrl(wedgeSelfie);

            await ReplyAsync("", false, builder.Build());

        }
    }
}

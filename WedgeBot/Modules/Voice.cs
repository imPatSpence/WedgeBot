using Discord;
using Discord.Commands;
using Discord.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WedgeBot.Services;

namespace WedgeBot.Modules
{
    public class Voice : ModuleBase
    {
        private static IAudioClient _audioclient;

        [Command("size", RunMode = RunMode.Async)]
        public async Task Size()
        {
            var staticUrl = "https://www.youtube.com/watch?v=siCnBQb7NeM";

            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            if (channel == null)
            {
                await ReplyAsync("Error: Couldn't find channel to join");
            }
            else
            {
                _audioclient = await channel.ConnectAsync();
                var ProcessYoutube = new ProcessYoutubeUrl();

                await ProcessYoutube.Play(staticUrl, _audioclient);
                await LeaveChannel();
            }
        }
        [Command("reportin1", RunMode = RunMode.Async)]
        public async Task ReportIn1()
        {
            var staticUrl = "https://www.youtube.com/watch?v=eEeTWVru1qc";

            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            if (channel == null)
            {
                await ReplyAsync("Error: Couldn't find channel to join");
            }
            else
            {
                _audioclient = await channel.ConnectAsync();

                var ProcessYoutube = new ProcessYoutubeUrl();

                await ProcessYoutube.Play(staticUrl, _audioclient);
                await LeaveChannel();
            }
        }
        [Command("reportin3", RunMode = RunMode.Async)]
        public async Task ReportIn3()
        {
            var staticUrl = "https://www.youtube.com/watch?v=uJmdeg4eqmU";

            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            if (channel == null)
            {
                await ReplyAsync("Error: Couldn't find channel to join");
            }
            else
            {
                _audioclient = await channel.ConnectAsync();
                var ProcessYoutube = new ProcessYoutubeUrl();

                await ProcessYoutube.Play(staticUrl, _audioclient);
                await LeaveChannel();
            }
        }
        private async Task LeaveChannel()
        {
            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            await _audioclient.StopAsync();
        }
    }
}


using Discord;
using Discord.Commands;
using Discord.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace WedgeBot.Modules
{
    public class SimpleVoice: ModuleBase
    {


        private static IAudioClient _audioclient;

        
        [Command("size", RunMode = RunMode.Async)]
        public async Task JoinChannel()
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

                await Play(staticUrl);
                await LeaveChannel();
            }
        }
        private async Task LeaveChannel()
        {
            IVoiceChannel channel = (Context.User as IVoiceState).VoiceChannel;
            await _audioclient.StopAsync();
        }

        private async Task Play(string url)
        {
            var ffmpeg = CreateStream(url);
            var output = ffmpeg.StandardOutput.BaseStream;
            var stream = _audioclient.CreatePCMStream(AudioApplication.Mixed);
            await output.CopyToAsync(stream);
            await stream.FlushAsync();
        }
        private Process CreateStream(string url)
        {
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C youtube-dl -o - {url} | ffmpeg -i pipe:0 -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            return Process.Start(ffmpeg);
        }

    }
}


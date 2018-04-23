using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Discord.Audio;
using Discord.WebSocket;

namespace WedgeBot.Services
{
    class ProcessYoutubeUrl
    {

        public async Task Play(string url, IAudioClient audioClient)
        { 
            var test = YoutubeDownload(url);
            var ffmpeg = CreateStream(url);
            var output = ffmpeg.StandardOutput.BaseStream;
            var stream = audioClient.CreatePCMStream(AudioApplication.Mixed);
            await output.CopyToAsync(stream);
            await stream.FlushAsync();
        }

        private Process YoutubeDownload(String url)
        {

            
            var download = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C youtube-dl --cache-dir /videos/test {url}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            return Process.Start(download);
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

using System.Diagnostics;
using System.Text.Json;
using SoundCloud.Term.MusicLibrary.Models;

namespace SoundCloud.Term.MusicLibrary.Services;

public class LiveYtdlpParser : IMetadataParser
{
    public async Task<Track> Parse(string input) {
        using var process = new Process();

        process.StartInfo.Arguments = $"--dump-json \"ytsearch1:{input}\""; 
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;

        process.Start();
        string outputText = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();

        if (string.IsNullOrWhiteSpace(outputText)) 
            throw new Exception("yt-dlp returned zero data. Verify your search or network connection.");

        using var jsonDoc = JsonDocument.Parse(outputText);
        var root = jsonDoc.RootElement;

        return new Track
        {
            SoundCloudId = root.GetProperty("id").GetString() ?? string.Empty,
            Title = root.GetProperty("title").GetString() ?? "Unknown Title",
            Artist = root.GetProperty("uploader").GetString() ?? "Unknown Artist",
            DurationSeconds = (int)root.GetProperty("duration").GetDouble(),
            WebpageUrl = root.GetProperty("webpage_url").GetString() ?? string.Empty
        };
    }
}

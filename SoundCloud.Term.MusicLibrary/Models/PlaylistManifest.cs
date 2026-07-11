using System.Text;

namespace SoundCloud.Term.MusicLibrary.Models;

public class PlaylistManifest
{
    public string ExportTitle { get; set; } = "SoundCloud Export";
    public string Author { get; set; } = "Unknown User";
    public string TargetOutputFormat { get; set; } = "Markdown";
    public StringBuilder Content { get; set; } = new();

    public string Render() => Content.ToString();
}

namespace SoundCloud.Term.MusicLibrary.Models;

public class Track
{
    public int Id { get; set; }
    public string SoundCloudId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public int DurationSeconds { get; set; }
    public string WebpageUrl { get; set; } = string.Empty;
    public string? LocalFilePath { get; set; }
    public DateTime IndexedAt { get; set; } = DateTime.UtcNow;
}

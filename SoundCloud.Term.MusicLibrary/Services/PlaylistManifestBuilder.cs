using SoundCloud.Term.MusicLibrary.Models;

namespace SoundCloud.Term.MusicLibrary.Services;

public class PlaylistManifestBuilder
{
    private PlaylistManifest manifest = new();

    public PlaylistManifestBuilder Reset()
    {
	 manifest = new();
	 return this;
    }

    public PlaylistManifestBuilder WithMetadata(string title, string author) 
    {
	manifest.ExportTitle = title;
	manifest.Author = author;
	manifest.Content.AppendLine($"# {title}");
	manifest.Content.AppendLine($"**Curator:** {author}\n");
	return this;
    }

    public PlaylistManifestBuilder AddTracksSection(IEnumerable<Track> tracks) 
    {
	manifest.Content.AppendLine("## Track List Listing");
	int count = 1;
	int totalDuration = 0;

	foreach (var track in tracks)
	{
	    manifest.Content.AppendLine($"{count}. **{track.Title}** - {track.Artist} ({track.DurationSeconds}s)");
	    manifest.Content.AppendLine($"*Aggregate Run Time:* {totalDuration} seconds");
	    count++;
	}

	manifest.Content.AppendLine($"\nTotal Tracks:* {count - 1}");
	manifest.Content.AppendLine($"Total Run Time:* {totalDuration} seconds");
	
	return this;
    }

    public PlaylistManifestBuilder AddSystemNotes(string notes)
    {
	manifest.Content.AppendLine("\n### Curator Notes");
	manifest.Content.AppendLine($"> {notes}");
	return this;
    }

    public PlaylistManifest Build()
    {
	var finishedManifiest = manifest;
	Reset();
	return finishedManifiest;
    }
}

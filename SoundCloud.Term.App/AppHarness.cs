using SoundCloud.Term.MusicLibrary.Data;
using SoundCloud.Term.MusicLibrary.Models;
using SoundCloud.Term.MusicLibrary.Services;

namespace SoundCloud.Term.App;

public class AppHarness(LibraryDbContext dbContext, MetadataParserFactory parserFactory, PlaylistManifestBuilder manifestBuilder)
{
    public async Task Run()
    {
        Console.WriteLine("\n[AppHarness]: Booting core workspace execution loop...");

        // Factory Pattern
        var state = ParserMode.Mock;

        var parser = parserFactory.CreateParser(state);

        Console.WriteLine("Container resolved subclass target -> {parser.GetType().Name}");

        var parsedTrack = await parser.Parse("Wooli Titans");
        await dbContext.Tracks.AddAsync(parsedTrack);
        await dbContext.SaveChangesAsync();

        // Builder Pattern
        var playList = new List<Track> { parsedTrack };

        var manifest = manifestBuilder
            .WithMetadata("Riddim Tracks", "Me")
            .AddTracksSection(playList)
            .AddSystemNotes("This is mock data which which will soon be replaced with real data")
            .Build();

        Console.WriteLine("\n=== Output Document Render ===");
        Console.WriteLine(manifest.Render());
    }
}

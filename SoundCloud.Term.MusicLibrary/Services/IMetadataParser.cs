using SoundCloud.Term.MusicLibrary.Models;

namespace SoundCloud.Term.MusicLibrary.Services;

public interface IMetadataParser 
{
    Task<Track> Parse(string input);
}

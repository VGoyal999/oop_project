using SoundCloud.Term.MusicLibrary.Models;

namespace SoundCloud.Term.MusicLibrary.Services;

public class MockMetadataParser : IMetadataParser 
{
    public async Task<Track> Parse(string input) 
    {
	await Task.Delay(0);
	return new Track 
	{
	    SoundCloudId = "mock_101",
	    Title = "Mock Track 1",
	    Artist = "Mock Artist",
	    DurationSeconds = 120,
	    WebpageUrl = "https://soundcloud.com/mock"
	};
    }
}

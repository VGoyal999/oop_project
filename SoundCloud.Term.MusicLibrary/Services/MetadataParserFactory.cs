using Microsoft.Extensions.DependencyInjection;

namespace SoundCloud.Term.MusicLibrary.Services;

public enum ParserMode
{
    Live, Mock
}

public class MetadataParserFactory(IServiceProvider serviceProvider)
{
    public IMetadataParser CreateParser(ParserMode mode)
    {
        Type parserType = mode switch
        {
            ParserMode.Live => typeof(LiveYtdlpParser),
            ParserMode.Mock => typeof(MockMetadataParser),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), $"Mode {mode} is not supported.")
        };

        var parser = serviceProvider.GetRequiredService(parserType) as IMetadataParser;
        return parser ?? throw new InvalidOperationException($"Could not resolve parser type for state: {mode}");
    }
}

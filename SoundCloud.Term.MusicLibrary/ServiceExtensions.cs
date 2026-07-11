using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoundCloud.Term.MusicLibrary.Data;
using SoundCloud.Term.MusicLibrary.Services;

namespace SoundCloud.Term.MusicLibrary;

public static class ServiceExtensions
{
    public static IServiceCollection AddMusicLibraryServices(this IServiceCollection services, string connectionString)
    {
	services.AddDbContext<LibraryDbContext>(options =>
	    options.UseNpgsql(connectionString));

	services.AddSingleton<MetadataParserFactory>();

	services.AddTransient<PlaylistManifestBuilder>();

	return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using Term.MusicPlayer.Ui.Services;

namespace Term.MusicPlayer.Ui;

public static class ServiceExtensions
{
    public static IServiceCollection AddUiServices(this IServiceCollection services)
    {
	services.AddTransient<IUiBuilder, UiBuilder>();

	return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using Term.MusicPlayer.Ui.Services.Builder;
using Term.MusicPlayer.Ui.Services.Factory;

namespace Term.MusicPlayer.Ui;

public static class ServiceExtensions
{
    public static IServiceCollection AddUiServices(this IServiceCollection services)
    {
	    services.AddTransient<IUiBuilder, UiBuilder>();

        services.AddKeyedTransient<LayerRenderFactory, HelpLayerRenderFactory>("help");
        services.AddKeyedTransient<LayerRenderFactory, SearchLayerRenderFactory>("search");
	    
        return services;
    }
}

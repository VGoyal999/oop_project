using Microsoft.Extensions.DependencyInjection;
using Term.MusicPlayer.Ui.Services.Builder;
using Term.MusicPlayer.Ui.Services.Factory;

namespace Term.MusicPlayer.App;

public class AppHarness(IServiceProvider serviceProvider, IUiBuilder uiBuilder)
{
    public void Run()
    {
        uiBuilder
    	    .AddSidebar(title: "📖 PLAYLISTS", widthPercent: 28)
    	    .AddMainPanel(title: "🎵 TERMINAL MUSIC PLAYER")
    	    .AddStatusLine(currentMode: "NORMAL", statusText: " init.lua | telescope.nvim search: <space>sf ")
    	    .Build();

	Console.SetCursorPosition(0, 23);
	Console.WriteLine("Press any key to simulate hitting <space>sf (Telescope search overlay)...");
	Console.ReadKey();

	var searchFactory = serviceProvider.GetRequiredKeyedService<LayerRenderFactory>("search");
	searchFactory.DrawLayerToScreen(row: 5, col: 20, width: 50, height: 7);

	Console.SetCursorPosition(0, 24);
	Console.WriteLine("Press any key to simulate hitting <space>sk (Help overlay)...");
	Console.ReadKey();

	var helpFactory = serviceProvider.GetRequiredKeyedService<LayerRenderFactory>("help");
	helpFactory.DrawLayerToScreen(row: 7, col: 25, width: 45, height: 6);

	Console.SetCursorPosition(0, 25);
	Console.ReadLine();
    }
}

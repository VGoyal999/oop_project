using Microsoft.Extensions.DependencyInjection;
using Term.MusicPlayer.Ui;
using Term.MusicPlayer.Ui.Services;

var services = new ServiceCollection();

services.AddUiServices();

var servicesProvider = services.BuildServiceProvider();

var uiBuilder = servicesProvider.GetRequiredService<IUiBuilder>();

uiBuilder
    .AddSidebar(title: "📖 PLAYLISTS", widthPercent: 28)
    .AddMainPanel(title: "🎵 TERMINAL MUSIC PLAYER")
    .AddStatusLine(currentMode: "NORMAL", statusText: " init.lua | telescope.nvim search: <space>sf ")
    .Build();

Console.SetCursorPosition(0, 23);
Console.ReadLine();

using Microsoft.Extensions.DependencyInjection;
using Term.MusicPlayer.App;
using Term.MusicPlayer.Ui;

var services = new ServiceCollection();

services.AddUiServices();

services.AddScoped<AppHarness>();

var serviceProvider = services.BuildServiceProvider();

var appHarness = serviceProvider.GetRequiredService<AppHarness>();

appHarness.Run();

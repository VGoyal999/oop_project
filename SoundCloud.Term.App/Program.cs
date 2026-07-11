using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoundCloud.Term.App;
using SoundCloud.Term.MusicLibrary;

Console.WriteLine("=== SoundDeck Initializing ===");

var builder = Host.CreateApplicationBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("librarydb")
    ?? throw new InvalidOperationException("Connection string 'librarydb' not found.");

builder.Services.AddMusicLibraryServices(connectionString);

builder.Services.AddScoped<AppHarness>();

var host = builder.Build();

using var scope = host.Services.CreateScope();

var harness = scope.ServiceProvider.GetRequiredService<AppHarness>();

await harness.Run();

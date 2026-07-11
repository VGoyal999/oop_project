var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var db = postgres.AddDatabase("soundcloud_term_db");

builder.AddProject<Projects.SoundCloud_Term_App>("app")
    .WithReference(db);

builder.Build().Run();

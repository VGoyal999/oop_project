using Microsoft.EntityFrameworkCore;
using SoundCloud.Term.MusicLibrary.Models;

namespace SoundCloud.Term.MusicLibrary.Data;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Track>().ToTable("library_tracks");
        modelBuilder.Entity<Track>().HasIndex(t => t.SoundCloudId).IsUnique();
    }
} 

using LoLMatchHistory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace LoLMatchHistory.Infrastructure;

public class LoLMatchHistoryContext(DbContextOptions<LoLMatchHistoryContext> contextOptions) : DbContext(contextOptions)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kill>()
            .HasOne<MatchInfo>()
            .WithMany(m => m.Kills)
            .HasPrincipalKey(m => m.GameHash)
            .HasForeignKey(k => k.GameHash)
            .HasConstraintName("FK_Kill_MatchInfo");

        modelBuilder.Entity<Bans>()
            .HasOne<MatchInfo>()
            .WithMany(m => m.Bans)
            .HasPrincipalKey(k => k.GameHash)
            .HasForeignKey(m => m.GameHash)
            .HasConstraintName("FK_Bans_MatchInfo");

        modelBuilder.Entity<Gold>()
            .HasOne<MatchInfo>()
            .WithMany(m => m.Gold)
            .HasPrincipalKey(k => k.GameHash)
            .HasForeignKey(m => m.GameHash)
            .HasConstraintName("FK_Gold_MatchInfo");

        modelBuilder.Entity<Monster>()
            .HasOne<MatchInfo>()
            .WithMany(m => m.Monsters)
            .HasPrincipalKey(k => k.GameHash)
            .HasForeignKey(m => m.GameHash)
            .HasConstraintName("FK_Monster_MatchInfo");

        modelBuilder.Entity<Structure>()
            .HasOne<MatchInfo>()
            .WithMany(m => m.Structures)
            .HasPrincipalKey(k => k.GameHash)
            .HasForeignKey(m => m.GameHash)
            .HasConstraintName("FK_Structure_MatchInfo");

        modelBuilder.Entity<MatchInfoOptimizedView>()
            .ToView("MatchInfoOptimizedView")
            .HasNoKey();

    }

    public DbSet<MatchInfo> Matches { get; set; }
    public DbSet<Bans> Bans { get; set; }
    public DbSet<Gold> Gold { get; set; }
    public DbSet<Kill> Kills { get; set; }
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<Structure> Structures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<MatchInfoOptimizedView> MatchInfoOptimized { get; set; }

}

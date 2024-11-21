using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

public class MatchDbContext : DbContext
{
    public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options) { }

    public DbSet<Match> Matches { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<MatchPlayer> MatchPlayers { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasMany(team => team.Players) //  a team has many players
            .WithOne(player => player.Team) // every player has one team
            .HasForeignKey(player => player.TeamId) // Player class's ID is the foreign key in Team class
            .OnDelete(DeleteBehavior.Cascade); // If I delete the Team, all its players are deleted (cascade)

        modelBuilder.Entity<Match>() // for Team A
            .HasOne(match => match.TeamA) // every match has a team A and a team B
            .WithMany()
            .HasForeignKey(match => match.TeamAId)
            .OnDelete(DeleteBehavior.Restrict); // if I delete the Match, the team stays

        modelBuilder.Entity<Match>() // for Team B
            .HasOne(match => match.TeamB) // every match has a team A and a team B
            .WithMany()
            .HasForeignKey(match => match.TeamBId)
            .OnDelete(DeleteBehavior.Restrict); // if I delete the Match, the team stays

        modelBuilder.Entity<MatchPlayer>() // Many to Many relation between a Match and a Player
            .HasKey(matchplayer => new { matchplayer.MatchId, matchplayer.PlayerId });

        modelBuilder.Entity<MatchPlayer>()
            .HasOne(matchplayer => matchplayer.Match) // Every match player has one match
            .WithMany(match => match.MatchPlayers) // every Match has many players...
            .HasForeignKey(matchplayer => matchplayer.MatchId);

        modelBuilder.Entity<MatchPlayer>()
            .HasOne(matchplayer => matchplayer.Player) // Every match player has one player
            .WithMany(player => player.MatchPlayers) // every player can play many matches
            .HasForeignKey(matchplayer => matchplayer.PlayerId);

        modelBuilder.Entity<Event>()
            .HasOne(eventt => eventt.Match)
            .WithMany(match => match.Events) // every Match can have many events
            .HasForeignKey(eventt => eventt.MatchId);
        modelBuilder.Entity<Event>()
            .HasOne(eventt => eventt.Player)
            .WithMany(player => player.Events) // every Player can have many events
            .HasForeignKey(eventt => eventt.PlayerId);

        
        // Seed Teams
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = 1, Name = "Team Alpha" },
            new Team { Id = 2, Name = "Team Beta" },
            new Team { Id = 3, Name = "Team Gamma" },
            new Team { Id = 4, Name = "Team Delta" }
        );

        // Seed Players
        modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, Name = "Alice", TeamId = 1, Number = 10, IsCaptain = false },
            new Player { Id = 2, Name = "Bob", TeamId = 1, Number = 11, IsCaptain = true },
            new Player { Id = 3, Name = "Charlie", TeamId = 2, Number = 8, IsCaptain = false },
            new Player { Id = 4, Name = "Daisy", TeamId = 2, Number = 9, IsCaptain = false },
            new Player { Id = 5, Name = "Eve", TeamId = 3, Number = 15, IsCaptain = true },
            new Player { Id = 6, Name = "Frank", TeamId = 3, Number = 12, IsCaptain = false },
            new Player { Id = 7, Name = "Grace", TeamId = 4, Number = 13, IsCaptain = false },
            new Player { Id = 8, Name = "Hank", TeamId = 4, Number = 14, IsCaptain = false }
        );

        // Seed Matches
        modelBuilder.Entity<Match>().HasData(
            new Match { Id = 1, EventName = "Championship Finals", MatchDateTime = DateTime.Now.AddDays(10), TeamAId = 1, TeamBId = 2 },
            new Match { Id = 2, EventName = "Summer League", MatchDateTime = DateTime.Now.AddDays(20), TeamAId = 3, TeamBId = 4 }
        );

        // Seed MatchPlayers (Assign players to matches)
        modelBuilder.Entity<MatchPlayer>().HasData(
            new MatchPlayer { MatchId = 1, PlayerId = 1 },
            new MatchPlayer { MatchId = 1, PlayerId = 2 },
            new MatchPlayer { MatchId = 1, PlayerId = 3 },
            new MatchPlayer { MatchId = 1, PlayerId = 4 },
            new MatchPlayer { MatchId = 2, PlayerId = 5 },
            new MatchPlayer { MatchId = 2, PlayerId = 6 },
            new MatchPlayer { MatchId = 2, PlayerId = 7 },
            new MatchPlayer { MatchId = 2, PlayerId = 8 }
        );

        // Seed Events
        modelBuilder.Entity<Event>().HasData(
            new Event { Id = 1, Hour = DateTime.Now, Type = "Goal", Points = 3, MatchId = 1, PlayerId = 1 },
            new Event { Id = 2, Hour = DateTime.Now.AddMinutes(5), Type = "Foul", Points = 0, MatchId = 1, PlayerId = 2 },
            new Event { Id = 3, Hour = DateTime.Now.AddMinutes(10), Type = "Goal", Points = 2, MatchId = 2, PlayerId = 5 }
        );
    }
}

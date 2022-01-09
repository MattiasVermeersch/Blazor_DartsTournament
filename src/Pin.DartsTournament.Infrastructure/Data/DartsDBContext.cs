using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using Pin.DartsTournament.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Data
{
    public class DartsDbContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Throw> Throws { get; set; }

        public DbSet<PlayerGame> PlayerGames { get; set; }

        public DartsDbContext(DbContextOptions<DartsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>()
                .ToTable("Tournaments")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Tournament>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .ToTable("Games")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Player>()
                .ToTable("Players")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .IsRequired();
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Tournament)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TournamentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Referee>()
                .ToTable("Referees")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Referee>()
                .Property(e => e.Name)
                .IsRequired();
            modelBuilder.Entity<Referee>()
                .HasOne(r => r.Tournament)
                .WithMany(t => t.Referees)
                .HasForeignKey(r => r.TournamentId);

            modelBuilder.Entity<Leg>()
                .ToTable("Legs")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Leg>()
                .HasOne(l => l.Game)
                .WithMany(g => g.Legs)
                .HasForeignKey(l => l.GameId);
            modelBuilder.Entity<Leg>()
                .HasOne(l => l.Player)
                .WithMany(p => p.Legs)
                .HasForeignKey(l => l.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Throw>()
                .ToTable("Throws")
                .HasKey(e => e.Id);

            modelBuilder.Entity<PlayerGame>()
                .ToTable("PlayerGames")
                .HasKey(pg => new { pg.PlayerId, pg.GameId });
            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.PlayerGames)
                .HasForeignKey(pg => pg.GameId)
                .OnDelete(DeleteBehavior.NoAction);

            TournamentSeeder.Seed(modelBuilder);
            PlayerSeeder.Seed(modelBuilder);
            RefereeSeeder.Seed(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

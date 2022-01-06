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
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .ToTable("Games")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Player>()
                .ToTable("Players")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Player>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<PlayerGame>()
                .ToTable("PlayerGame")
                .HasKey(pg => new { pg.PlayerId, pg.GameId });
            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerGames);
            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Game)
                .WithMany(g => g.PlayerGames);

            modelBuilder.Entity<Referee>()
                .ToTable("Referees")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Referee>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Leg>()
                .ToTable("Legs")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Throw>()
                .ToTable("Throws")
                .HasKey(e => e.Id);

            TournamentSeeder.Seed(modelBuilder);
            PlayerSeeder.Seed(modelBuilder);
            RefereeSeeder.Seed(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

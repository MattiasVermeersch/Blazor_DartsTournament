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
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Throw> Throws { get; set; }
        public DbSet<PlayerLeg> PlayerLegs { get; set; }

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

            modelBuilder.Entity<Leg>()
                .ToTable("Legs")
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

            modelBuilder.Entity<Set>()
                .ToTable("Sets")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Set>()
                .HasOne(s => s.Leg)
                .WithMany(g => g.Sets)
                .HasForeignKey(l => l.LegId);
            modelBuilder.Entity<Set>()
                .HasOne(l => l.Player)
                .WithMany(p => p.Sets)
                .HasForeignKey(l => l.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Throw>()
                .ToTable("Throws")
                .HasKey(e => e.Id);

            modelBuilder.Entity<PlayerLeg>()
                .ToTable("PlayerLegs")
                .HasKey(pg => new { pg.PlayerId, pg.LegId });
            modelBuilder.Entity<PlayerLeg>()
                .HasOne(pg => pg.Player)
                .WithMany(p => p.PlayerLegs)
                .HasForeignKey(pg => pg.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PlayerLeg>()
                .HasOne(pg => pg.Leg)
                .WithMany(g => g.PlayerLegs)
                .HasForeignKey(pg => pg.LegId)
                .OnDelete(DeleteBehavior.NoAction);

            TournamentSeeder.Seed(modelBuilder);
            PlayerSeeder.Seed(modelBuilder);
            RefereeSeeder.Seed(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

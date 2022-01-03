using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Data
{
    public class DartsDBContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Dart> Darts { get; set; }

        public DartsDBContext(DbContextOptions<DartsDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().ToTable("Tournaments").HasKey(e => e.Id);

            modelBuilder.Entity<Game>().ToTable("Games").HasKey(e => e.Id);

            modelBuilder.Entity<Player>().ToTable("Players").HasKey(e => e.Id);
            modelBuilder.Entity<Player>().Property(e => e.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Referee>().ToTable("Referees").HasKey(e => e.Id);
            modelBuilder.Entity<Referee>().Property(e => e.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Leg>().ToTable("Legs").HasKey(e => e.Id);

            modelBuilder.Entity<Dart>().ToTable("Darts").HasKey(e => e.Id);
        }
    }
}

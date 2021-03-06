using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Data.Seeding
{
    public class PlayerSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Name = "Jane Doe",
                    TournamentId = 100
                },
                new Player
                {
                    Id = 2,
                    Name = "John Doe",
                    TournamentId = 100
                },
                new Player
                {
                    Id = 3,
                    Name = "Harry Potter",
                    TournamentId = 100
                },
                new Player
                {
                    Id = 4,
                    Name = "Mr. Anderson",
                    TournamentId = 100
                }
            );
        }
    }
}

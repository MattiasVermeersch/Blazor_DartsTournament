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
                    Name = "Jane Doe"
                },
                new Player
                {
                    Id = 2,
                    Name = "John Doe"
                },
                new Player
                {
                    Id = 3,
                    Name = "Harry Potter"
                },
                new Player
                {
                    Id = 4,
                    Name = "Mr. Anderson"
                },
                new Player
                {
                    Id = 5,
                    Name = "Pablo Picasso"
                },
                new Player
                {
                    Id = 6,
                    Name = "Johan Vermeer"
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Data.Seeding
{
    public class TournamentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().HasData(
                new Tournament
                {
                    Id = 100,
                    Name = "Conf-IT-uurtjes Toernooi",
                    Date = new DateTime(2022, 01, 24)
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pin.DartsTournament.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.DartsTournament.Infrastructure.Data.Seeding
{
    public class RefereeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referee>().HasData(
                new Referee
                {
                    Id = 30,
                    Name = "Lector Deboosere"
                },
                new Referee
                {
                    Id = 31,
                    Name = "Lector Derdeyn"
                }
            );
        }
    }
}

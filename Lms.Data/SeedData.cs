using Bogus;
using Lms.Core;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data
{
    public class SeedData
    {
        private static LmsapiContext db = default!;


        public static async Task InitAsync(LmsapiContext _context, IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(nameof(_context));
            db = _context;
            if (db.Tournament.Any()) return;

            ArgumentNullException.ThrowIfNull(nameof(services));


            var tournaments = GetTournaments(3);
            await db.AddRangeAsync(tournaments);
            await db.SaveChangesAsync();

            var tournamentsInDb = await db.Tournament.ToListAsync();

            var games = GetGames(5, tournamentsInDb);
            await db.AddRangeAsync(games);
            await db.SaveChangesAsync();

        }

        private static IEnumerable<Game> GetGames(int gamesPerTournament, List<Tournament> tournaments)
        {
           var faker = new Faker("sv");

            var games = new List<Game>();


            foreach(var tournament in tournaments)
            {
                for(int i = 0; i < gamesPerTournament; i++)
                {
                    var game = new Game
                    {
                        Title = faker.Name.FirstName() + " vs " + faker.Name.FirstName(),
                        Time = tournament.StartDate.AddHours(faker.Random.Int(-5, 5)),
                        TournamentId = tournament.Id
                    };
                    games.Add(game);
                }
                
            }


            return games;
        }

        private static IEnumerable<Tournament> GetTournaments(int nrOfTournaments)
        {
            var faker = new Faker("sv");

            var tournaments = new List<Tournament>();

            for (int i = 0; i < nrOfTournaments; i++)
            {
                var temp = new Tournament
                {
                    
                    Title = faker.Name.FullName() + " - " + faker.Commerce.ProductName(),
                    StartDate = DateTime.Now.AddDays(faker.Random.Int(-5, 5))
                };
                tournaments.Add(temp);
            }

            return tournaments;
        }

    }
}

using Bogus.DataSets;
using Lms.Core;
using Lms.Core.Repositories;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly LmsapiContext db;

        public GameRepository(LmsapiContext _context)
        {
            db = _context;
        }

        public void Add(Game game)
        {
            db.Add(game);
        }

        public async Task<bool> AnyAsync(string title)
        {
            return await db.Game.AnyAsync(m => m.Title == title);
        }



        public async Task<IEnumerable<Game>> GetAllAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }
            
            var result = await db.Game.Where(g => g.Tournament.Title==title).ToListAsync();
            return result;
        }




        public async Task<Game> GetAsync(string title, int id)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            var result = await db.Game.Include(t => t.Tournament).Where(t => t.Id==id).FirstOrDefaultAsync();
            //var result = await db.Game.FirstOrDefaultAsync(m=>m.Tournament.Title==title && m.Id==id);
            //var result =await db.Game.Where(m => m.Tournament.Title==title && m.Id==id).FirstOrDefaultAsync(m => m.Id==id);
            return result;
        }

        public void Remove(Game game)
        {
            db.Remove(game);
        }

        public void Update(Game game)
        {
            db.Update(game);
        }
    }
}

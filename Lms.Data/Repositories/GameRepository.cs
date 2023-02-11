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

        public async Task<bool> AnyAsync(int id)
        {
            return await db.Game.AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await db.Game.ToListAsync() ?? throw new ArgumentNullException(nameof(db.Game));
        }

        public async Task<Game> GetAsync(int id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return await db.Game.FirstOrDefaultAsync(m => m.Id == id);
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

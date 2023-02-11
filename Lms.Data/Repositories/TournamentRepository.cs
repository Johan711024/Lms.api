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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly LmsapiContext db;

        public TournamentRepository(LmsapiContext _context)
        {
            db = _context;
        }

        public void Add(Tournament tournament)
        {
            db.Add(tournament);
        }

        public Task<bool> AnyAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            return db.Tournament.AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {

            return await db.Tournament.ToListAsync() ?? throw new ArgumentNullException(nameof(db.Tournament));
        }


        public async Task<Tournament> GetAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            return await db.Tournament.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Remove(Tournament tournament)
        {
            db.Remove(tournament);
        }

        public void Update(Tournament tournament)
        {
            db.Update(tournament);
        }
    }
}

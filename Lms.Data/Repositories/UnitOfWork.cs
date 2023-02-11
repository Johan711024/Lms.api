using Lms.Core.Repositories;
using Lms.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LmsapiContext db;

        public ITournamentRepository TournamentRepository { get; private set; }
        public IGameRepository GameRepository { get; private set; }

        public UnitOfWork(LmsapiContext context)
        {
            db = context;
            TournamentRepository = new TournamentRepository(db);
            GameRepository = new GameRepository(db);
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}

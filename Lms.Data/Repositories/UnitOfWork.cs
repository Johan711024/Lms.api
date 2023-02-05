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

        public UnitOfWork(LmsapiContext context)
        {
            db = context;
        }

        IGameRepository IUnitOfWork.GameRepository => throw new NotImplementedException();

        ITournamentRepository IUnitOfWork.TournamentRepository => throw new NotImplementedException();

        Task IUnitOfWork.CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}

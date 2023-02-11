using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync(string title);
        Task<Game> GetAsync(string title, int id);
        Task<bool> AnyAsync(string title);
        void Add(Game game);
        void Update(Game game);
        void Remove(Game game);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core
{
#nullable disable
    public class Game
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public DateTime Time { get; set; }

        //Foreign key
        public int TournamentId { get; set; }

        //Nav prop
        public Tournament Tournament { get; set; }
    }
}

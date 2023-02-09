using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Common.DTOs
{
#nullable disable
    public class TournamentDto
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public ICollection<Game> Games { get; set; }
    }
}

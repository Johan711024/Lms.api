using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lms.Core;

namespace Lms.Data.Data
{
    public class LmsapiContext : DbContext
    {
        public LmsapiContext(DbContextOptions<LmsapiContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament> Tournament { get; set; } = default!;

        public DbSet<Game> Game { get; set; } = default!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChallengeBombs.Models;

namespace ChallengeBombs.Data
{
    public class ChallengeBombsContext : DbContext
    {
        public ChallengeBombsContext (DbContextOptions<ChallengeBombsContext> options)
            : base(options)
        {
        }

        public DbSet<ChallengeBombs.Models.Bomb> Bomb { get; set; }
    }
}

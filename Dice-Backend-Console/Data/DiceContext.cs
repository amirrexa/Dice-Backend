using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dice_Backend_Console.Data
{
    public class DiceContext : DbContext
    {
        public DiceContext()
        {
        }

        public DiceContext(DbContextOptions<DiceContext> options)
        : base(options)
        {
        }
        public DbSet<GameHistoryEntry> GameHistory { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DiceDB;Trusted_Connection=True;Encrypt=False;"); //Encrypt False Ro Nazari Kar Nemikone
        }
    }
}
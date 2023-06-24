using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Data
{
    public class GameHistoryEntry
    {
        public GameHistoryEntry(string outcomeResult, string walletAddress, float multiplier, int rolledValue, decimal payout, DateTime time)
        {
            OutcomeResult = outcomeResult;
            WalletAddress = walletAddress;
            Multiplier = multiplier;
            RolledValue = rolledValue;
            Payout = payout;
            Time = time;
        }
        [Key]
        public int Id { get; set; }
        public string OutcomeResult { get; set; }
        public string WalletAddress { get; set; }
        public float Multiplier { get; set; }
        public int RolledValue { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Payout { get; set; }
        public DateTime Time { get; set; }
    }
}

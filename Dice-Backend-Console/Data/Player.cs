using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Data
{
    public class Player
    {
        public Player(string walletAddress, decimal balance)
        {
            WalletAddress = walletAddress;
            Balance = balance;
        }
        [Key]
        public string WalletAddress { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
    }
}
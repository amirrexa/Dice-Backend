using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Data.Repository
{
    public interface IDiceRepository
    {
        //void CreatePlayer(string walletAddress, decimal balance);
        Player GetPlayerByWalletAddress(string walletAddress);
        void AddGameHistoryEntry(string outcomeResult, string playerWalletAddress, float multiplier, int rolledValue, decimal payout, DateTime time);
        List<GameHistoryEntry> GetAllGameHistory();
    }
}
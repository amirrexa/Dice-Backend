using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Data.Repository
{
    public class DiceRepository : IDiceRepository
    {
        private DiceContext diceContext;
        public DiceRepository()
        {
            diceContext = new DiceContext();
        }
        public List<GameHistoryEntry> GetAllGameHistory()
        {
            return diceContext.GameHistory.ToList();
        }

        public void AddGameHistoryEntry(string outcomeResult, string playerWalletAddress, float multiplier, int rolledValue, decimal payout, DateTime time)
        {
            diceContext.GameHistory.Add(new GameHistoryEntry(outcomeResult, playerWalletAddress, multiplier, rolledValue, payout, time));
            diceContext.SaveChanges();
        }

        public Player GetPlayerByWalletAddress(string walletAddress)
        {   
            var player = diceContext.Players.FirstOrDefault(p => p.WalletAddress == walletAddress);
            if (player == null)
            {
                diceContext.Players.Add(new Player(walletAddress, 100));
                diceContext.SaveChanges();
                return GetPlayerByWalletAddress(walletAddress); //recursive
            }
            else
                return player;
        }

        //public void CreatePlayer(string walletAddress, decimal balance)
        //{
            
        //    diceContext.Players.Add(new Player(walletAddress, balance));
        //    diceContext.SaveChanges();  
        //}

        public void DeletePlayer(Player player)
        {
            diceContext.Players.Remove(player);
            diceContext.SaveChanges();
        }

        public void AddToWalletBalance(Player player, decimal value)
        {
            player.Balance += value;
        }
    }
}

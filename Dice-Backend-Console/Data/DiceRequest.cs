using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Data
{
    public class DiceRequest
    {
        public DiceRequest(string walletAddress, decimal walletBalance, int sliderValue, string selectedCurrency, decimal betAmount, float multiplier)
        {
            WalletAddress = walletAddress;
            WalletBalance = walletBalance;
            SliderValue = sliderValue;
            SelectedCurrency = selectedCurrency;
            BetAmount = betAmount;
            Multiplier = multiplier;
        }

        public string WalletAddress { get; set; }
        public decimal WalletBalance { get; set; }
        public int SliderValue { get; set; }
        public string SelectedCurrency { get; set; }
        public decimal BetAmount { get; set; }
        public float Multiplier { get; set; }
    }
}
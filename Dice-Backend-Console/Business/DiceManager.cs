using Dice_Backend_Console.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Backend_Console.Business
{
    public class DiceManager
    {
        public (decimal payout, int rolledValue) Roll(DiceRequest request)
        {
            var random = new Random();
            int rolledValue = random.Next(0, 99);
            decimal payout = request.BetAmount * (decimal)request.Multiplier;

            if (rolledValue >= request.SliderValue)
            {
                return (payout, rolledValue);
            }
            else
            {

                return (payout * -1, rolledValue);
            }
        }
    }
}
using Dice_Backend_Console.Business;
using Dice_Backend_Console.Data;
using Dice_Backend_Console.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dice_Backend_Web.Controllers
{
    [Route("[controller]")]
    public class DiceController : Controller
    {
        private readonly IDiceRepository _diceRepository;
        private readonly DiceManager _diceManager;
        public DiceController(IDiceRepository diceRepository, DiceManager diceManager)
        {
            _diceManager = diceManager;
            _diceRepository = diceRepository;
        }

        [Route("AllEntries")]
        public ActionResult<List<GameHistoryEntry>> GetAllGameHistory()
        {
            return _diceRepository.GetAllGameHistory();
        }

        [Route("Roll")]
        [HttpPost]
        public IActionResult RollDice(IFormCollection form)
        {
            string walletAddress = form["walletAddress"];
            decimal walletBalance = Convert.ToDecimal(form["walletBalance"]);
            int sliderValue = Convert.ToInt32(form["sliderValue"]);
            string selectedCurrency = form["selectedCurrency"];
            decimal betAmount = Convert.ToDecimal(form["betAmount"]);
            float multiplier = Convert.ToSingle(form["multiplier"]);
            var request = new DiceRequest(walletAddress, walletBalance, sliderValue, selectedCurrency, betAmount, multiplier);
            if (request.BetAmount > request.WalletBalance)
            {
                return BadRequest("Invalid bet amount");
            }

            var rollResult = _diceManager.Roll(request);
            string outcomeResult = rollResult.payout > 0 ? "Won" : "Busted";

            var wonPlayer = _diceRepository.GetPlayerByWalletAddress(walletAddress);
            _diceRepository.AddToWalletBalance(wonPlayer, rollResult.payout);

            _diceRepository.AddGameHistoryEntry(outcomeResult, request.WalletAddress, request.Multiplier, rollResult.rolledValue, rollResult.payout, DateTime.Now);
            return Ok(outcomeResult);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult LoadPlayer(string walletAddress)
        {
            var player = _diceRepository.GetPlayerByWalletAddress(walletAddress);
            return Ok(player);
        }
    }
}
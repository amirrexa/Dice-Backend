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
        public IActionResult RollDice([FromBody]RollRequest request)
        {
            if (request.BetAmount > request.WalletBalance)
            {
                return BadRequest("Invalid bet amount");
            }
            else
            {
            var rollResult = _diceManager.Roll(request);
            string outcomeResult = rollResult.payout > 0 ? "Won" : "Busted";

            var player = _diceRepository.GetPlayerByWalletAddress(request.WalletAddress);
            _diceManager.AddToWalletBalance(player, rollResult.payout);

            _diceRepository.AddGameHistoryEntry(outcomeResult, request.WalletAddress, request.Multiplier, rollResult.rolledValue, rollResult.payout, DateTime.Now);
            return Json(outcomeResult, player.Balance);
            }
        }

        [Route("[action]")]
        [HttpGet]
        public Player LoadPlayer(string walletAddress)
        {
            var player = _diceRepository.GetPlayerByWalletAddress(walletAddress);
            return player;
        }
    }
}
using CS233_ASPnet_TicTacToe_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CS233_ASPnet_TicTacToe_JohnMoreau.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            // Coalescing null to new game
            var game = HttpContext.Session.GetObject<TicTacToe>("game") ??  new TicTacToe();


            return View(game);
        }

        [HttpPost]
        public IActionResult Update([FromForm] TicTacToe game, string id)
        {

            // Could not get the binding to match to a TicTacToe object game.Board array, it would always be intitialized with a blank board.
            // The game isn't picking up all of the fields and seems to be initializing a new board array each time...


            // This works instead... 
            //var game = new TicTacToe(board, currentPlayer, int.Parse(id));

            // Or this
            game.Board = JsonConvert.DeserializeObject<string[]>(game.BoardString) ?? TicTacToe.InitializeBoard();

            game.LastId = int.Parse(id);
            game.Board[int.Parse(id)] = game.CurrentPlayer;
            game.SwitchPlayer();

            HttpContext.Session.SetObject("game", game);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Restart()
        {
            return RedirectToAction("Index", "Home", new { game = new TicTacToe() });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

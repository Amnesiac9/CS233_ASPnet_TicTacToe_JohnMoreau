using CS233_ASPnet_TicTacToe_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Update(TicTacToe game, string id)
        {

            //var session = new TicTacToeSession(HttpContext.Session);
            // The game isn't picking up all of the fields and seems to be initializing a new game object each time this is called...

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

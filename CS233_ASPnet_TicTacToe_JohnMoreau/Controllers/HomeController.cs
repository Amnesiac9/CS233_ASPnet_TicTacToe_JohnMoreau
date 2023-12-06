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
        public IActionResult Update([FromForm] TicTacToe game)
        {

            // Could not get the binding to match to a TicTacToe object game.Board array, it would always be intitialized with a blank board,
            // or it would come through as system.string[] if using a single field.
            // The game isn't picking up all of the fields and seems to be initializing a new board array each time...
            // Also tried with a List of strings, but end up duplicating each time the object is deserialized due to my constructor using a default board,
            // the updated board simply gets appended upon deserialization. 


            // This works instead... passing in each field seperately
            //var game = new TicTacToe(board, currentPlayer, int.Parse(id));

            // Or store the serialized (string) version as a attribute of the class and that can be bound easily.
            // Why can't the model simply do this step correctly when passing back the board as a List or Array of strings???
            game.Board = JsonConvert.DeserializeObject<string[]>(game.BoardString) ?? TicTacToe.InitializeBoard();
            game.Board[game.LastId] = game.CurrentPlayer;
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

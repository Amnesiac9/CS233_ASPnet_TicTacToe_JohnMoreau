using CS233_ASPnet_TicTacToe_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS233_ASPnet_TicTacToe_JohnMoreau.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(TicTacToe game)
        {
            // Coalescing null to new game
            game ??= new TicTacToe();


            return View(game);
        }

        public IActionResult Update(TicTacToe game)
        {
            return RedirectToAction("Index", "Home", new {game});
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

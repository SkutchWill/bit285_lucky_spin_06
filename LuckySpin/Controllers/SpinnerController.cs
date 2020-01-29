using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random;
        Repository repository;
        

        /***
         * Controller Constructor
         */
        public SpinnerController(Repository repository)
        {
            random = new Random();
            //TODO: Inject the Repository singleton
            this.repository = repository;
        }

        /***
         * Entry Page Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }
        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid) { return View(); }

            // TODO: Add the Player to the Repository

            // TODO: Build a new SpinItViewModel object with data from the Player and pass it to the View
            repository.Player = indexViewModel.Player;
            IndexViewModel indexViewModel = new IndexViewModel(player);
            indexViewModel.StartingBalance = player.StartingBalance;
            SpinViewModel Spinit = new SpinViewModel (player);
            Spinit.Balance = player.StartingBalance;

            return RedirectToAction("SpinIt", player); 
        }

        /***
         * Spin Action - Game Play
         **/  
         public IActionResult SpinIt(SpinViewModel Spinit) //TODO: replace the parameter with a ViewModel

        {
            
            {
                Spinit.Balance = repository.Player.Balance;
                Spinit.Luck = repository.Player.Luck;
                Spinit.A = random.Next(1, 10);
                Spinit.B = random.Next(1, 10);
                Spinit.C = random.Next(1, 10);
            };

            Spinit.IsWinning = (Spinit.A == Spinit.Luck || Spinit.B == Spinit.Luck || Spinit.C == Spinit.Luck);
            if (Spinit.IsWinning)
            {
                
            }
            else
            {
                
            }
            
            //Add to Spin Repository
            repository.AddSpin(Spinit);

            //TODO: Clean up ViewBag using a SpinIt ViewModel instead
            ViewBag.ImgDisplay = (Spinit.IsWinning) ? "block" : "none";
            ViewBag.FirstName = repository.Player.FirstName;
            ViewBag.Balance = Spinit.Balance;

            return View("SpinIt", Spinit);
        }

        /***
         * LuckList Action - End of Game
         **/
         public IActionResult LuckList()
        {
                return View(repository.PlayerSpins);
        }
    }
}


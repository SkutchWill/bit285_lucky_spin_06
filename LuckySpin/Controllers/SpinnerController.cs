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
        
        Repository repository;
        

        /***
         * Controller Constructor
         */
        public SpinnerController(Repository repository)
        {
            
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

            repository.Player = player;
            repository.Player.Balance = player.StartingBalance;
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
            

            
            
            //Add to Spin Repository
            
            

            //TODO: Clean up ViewBag using a SpinIt ViewModel instead      

            if (repository.Player.ChargeSpin())
            {
                Spinit.Spin(repository);
                repository.AddSpin(Spinit);
                return View(Spinit.returnValue, Spinit);                
            }
            return RedirectToAction("LuckList", repository.PlayerSpins);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckySpin.Models;

namespace LuckySpin.ViewModels
{
    public class SpinViewModel
    {
        Random random = new Random();
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public decimal Balance { get; set; }
        public bool IsWinning { get; set; }
        public int Luck { get; set; }
        public string FirstName { get; set; }
        public string ImgDisplay;
        public string returnValue = "SpinIt";
        
        public SpinViewModel()
        {

        }
        
        public SpinViewModel(Player player)
        {
            this.Luck = player.Luck;
            this.FirstName = player.FirstName;
            this.Balance = player.StartingBalance;
        }
        public string Spin(Repository player)
        {
            //if(player.Player.ChargeSpin())
            //{                
                A = random.Next(1, 10);
                B = random.Next(1, 10);
                C = random.Next(1, 10);
                IsWinning = (A == Luck || B == Luck || C == Luck);
                if (IsWinning)
                {
                    player.Player.CollectWinnings();
                    Balance = player.Player.Balance;
                    ImgDisplay = "block";
                    return returnValue;
                }
                Balance = player.Player.Balance;
                ImgDisplay = "none";
                return returnValue;                
            //}
            //return returnValue;
            
        }
    }
}

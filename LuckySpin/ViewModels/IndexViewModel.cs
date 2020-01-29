using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckySpin.Models;

namespace LuckySpin.ViewModels
{
    public class IndexViewModel
    {
        public string FirstName { get; set; }
        public int Luck { get; set; }
        public decimal StartingBalance { get; set; }
        public Player Player { get; set; }
        IndexViewModel()
        {
            this.Player.FirstName = this.FirstName;
            this.Player.Luck = this.Luck;
            this.Player.StartingBalance = Player.StartingBalance;
        }

        
    }
}

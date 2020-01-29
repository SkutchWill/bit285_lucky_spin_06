using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuckySpin.Models;
using System.ComponentModel.DataAnnotations;

namespace LuckySpin.ViewModels
{
    public class IndexViewModel
    {
        [Display(Prompt = " Your First Name")]
        [Required(ErrorMessage = "Please enter your Name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Range(1, 9, ErrorMessage = "Choose a number")]
        public int Luck { get; set; }
        [Display(Prompt = " Starting Balance $3 to $10")]
        [Range(3, 10, ErrorMessage = "Please enter a valid number")]
        public decimal StartingBalance { get; set; }
        public Player Player { get; set; }
        public IndexViewModel(Player player)
        {
            Player = player;
        }       


    }
}

using PizzaWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApp.ViewModels
{
    public class IndivPizza_Size_Crust_Ingredients
    {
        //public Indiv_pizza indivpizza { get; set; }
        public decimal? totalcost { get; set; }
        [DisplayName("Ingredients")]
        public List<string> ingredients { get; set; } = new List<string>();
        public Crust crust { get; set; }
        public Size size { get; set; }
        public Orderpizza order { get; set; }
    }
}

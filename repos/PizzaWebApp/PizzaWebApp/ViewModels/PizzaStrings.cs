using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWebApp.Models;

namespace PizzaWebApp.ViewModels
{
    public class PizzaStrings
    {
        public Indiv_pizza ip { get; set; } = new Indiv_pizza();
        public List<SelectListItem> ingredientlist = new List<SelectListItem>
        {
            new SelectListItem { Value = "none", Text = "Empty" },
            new SelectListItem { Value = "chicken", Text = "Chicken +$1.25" },
            new SelectListItem { Value = "steak", Text = "Steak +$1.50"  },
            new SelectListItem { Value = "bacon", Text = "Bacon +$1.25"  },
            new SelectListItem { Value = "pepperoni", Text = "Pepperoni +$1.25"  },
            new SelectListItem { Value = "proscuitto", Text = "Proscuitto +$1.75"  },
            new SelectListItem { Value = "tomatoes", Text = "Tomatoes +$1.25"  },
            new SelectListItem { Value = "garlic", Text = "Garlic +$1.00"  },
            new SelectListItem { Value = "onions", Text = "Onions +$1.00"  },
            new SelectListItem { Value = "bell peppers", Text = "Bell Peppers +$1.00"  },
            new SelectListItem { Value = "ham", Text = "Ham +$1.25"  },
        };
        public List<SelectListItem> crustlist { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "regular", Text = "Regular +$0.00" },
            new SelectListItem { Value = "thin", Text = "Thin +$.75" },
            new SelectListItem { Value = "garlic", Text = "Garlic +$1.00"  },
            new SelectListItem { Value = "cheesy", Text = "Cheesy +$1.00"}
        };
        public List<SelectListItem> sizelist { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "small", Text = "Small +$4.00" },
            new SelectListItem { Value = "medium", Text = "Medium +$5.00" },
            new SelectListItem { Value = "large", Text = "Large +$6.50"  },

        };
        public string ing0 { get; set; }
        public string ing1 { get; set; }
        public string ing2 { get; set; }
        public string ing3 { get; set; }
        public string ing4 { get; set; }
        public string crustFID { get; set; }
        public string sizeFID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public string Restaurant()
        {
            return "This is my Restaurant action method";
        }
    }
}
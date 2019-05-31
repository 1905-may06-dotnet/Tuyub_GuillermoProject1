using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILocationRepository db;
        public IActionResult Index()
        {
            var locations = db.GetRestaurants();
            foreach (var location in locations)
            {
            }
            return View();
        }


        public string Restaurant()
        {
            return "This is my Restaurant action method";
        }
    }
}
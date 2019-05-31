using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILocationRepository db;
        private readonly IPizzaLogicRepo db2;

        public RestaurantController(ILocationRepository db)
        {
            this.db = db;
        }
        PizzaWebApp.Models.ResLocation loc;
        List<PizzaWebApp.Models.ResLocation> locationlist = new List<PizzaWebApp.Models.ResLocation>();

        public IActionResult Index(int id=0)
        {

            var locations = db.GetRestaurants();
            foreach (var location in locations)
            {
                
                loc = new Models.ResLocation();
                loc.City = location.City;
                if (location.locationID == 0)
                    loc.LocationId = location.locationID;
                else
                    loc.LocationId = id;
                loc.ResName = location.ResName;
                loc.State = location.State;
                loc.Zipcode = location.Zipcode;
                locationlist.Add(loc);
                
            } 

            return View(locationlist);
        }   
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST:Restaurant/Create
        public ActionResult Create(IFormCollection collection, PizzaWebApp.Models.ResLocation reslocation)
        {
            Domain.ResLocation dmc = new ResLocation();
            dmc.City = reslocation.City;
            dmc.locationID = reslocation.LocationId;
            dmc.ResName = reslocation.ResName;
            dmc.State = reslocation.State;
            dmc.Zipcode = reslocation.Zipcode;

            try
            {
                db.AddLocation(dmc);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult OrderPizza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderPizza(IFormCollection collection, PizzaWebApp.Models.PizzaLogic.Orderpizza op)
        {
            Domain.PizzaLogic.Orderpizza dmc = new Domain.PizzaLogic.Orderpizza();
            dmc.orderid = op.orderid;
            dmc.locationfid_op = op.locationfid_op;
            dmc.userFID = op.userFID;
            dmc.Timecheck = op.Timecheck;
            dmc.Timecheckdefault = op.Timecheckdefault;

            try
            {
                db2.AddOrder(dmc);
                db2.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Pizzabuilder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pizzabuilder(IFormCollection collection, PizzaWebApp.Models.PizzaLogic.Indiv_pizza ip)
        {
            Domain.PizzaLogic.Indiv_pizza dmc = new Domain.PizzaLogic.Indiv_pizza();
            dmc.count = ip.count;
            dmc.crustFID = ip.crustFID;
            dmc.Ingredient0FID = ip.Ingredient0FID;
            dmc.Ingredient1FID = ip.Ingredient1FID;
            dmc.Ingredient2FID = ip.Ingredient2FID;
            dmc.Ingredient3FID = ip.Ingredient3FID;
            dmc.Ingredient4FID = ip.Ingredient4FID;
            dmc.orderFID = ip.orderFID;
            dmc.pizzaId = ip.pizzaId;
            dmc.sizeFID = ip.sizeFID;
            dmc.totalcost = ip.totalcost;


            try
            {
                db2.AddPizza(dmc);
                db2.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
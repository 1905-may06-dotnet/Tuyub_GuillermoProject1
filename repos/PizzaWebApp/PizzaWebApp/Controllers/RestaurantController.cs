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
        public RestaurantController(ILocationRepository db, IPizzaLogicRepo db2)
        {
            this.db = db;
            this.db2 = db2;
        }
        PizzaWebApp.Models.ResLocation loc;
        List<PizzaWebApp.Models.ResLocation> locationlist = new List<PizzaWebApp.Models.ResLocation>();


        public IActionResult Index()
        {

            var locations = db.GetRestaurants();
            foreach (var location in locations)
            {
                
                loc = new Models.ResLocation();
                loc.City = location.City;
                loc.LocationId = location.locationID;
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
        public ActionResult OrderPizza(IFormCollection collection, PizzaWebApp.Models.Orderpizza op)
        {
            Domain.Orderpizza dmc = new Domain.Orderpizza();
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
            var ip = new PizzaWebApp.Models.Indiv_pizza();
            ip.Ingredient0FID = "none";
            ip.Ingredient1FID = "none";
            ip.Ingredient2FID = "none";
            ip.Ingredient3FID = "none";
            ip.Ingredient4FID = "none";
            
            return View(ip);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pizzabuilder(Models.Indiv_pizza ip, int? id)
        {            
           
            Domain.Indiv_pizza dmc = new Domain.Indiv_pizza();

            dmc.count = ip.count;
            dmc.crustFID = db2.CrustStringToID(ip.crustFID);
            dmc.Ingredient0FID = db2.IngredientStringToId(ip.Ingredient0FID);
            dmc.Ingredient1FID = db2.IngredientStringToId(ip.Ingredient1FID);
            dmc.Ingredient2FID = db2.IngredientStringToId(ip.Ingredient2FID);
            dmc.Ingredient3FID = db2.IngredientStringToId(ip.Ingredient3FID);
            dmc.Ingredient4FID = db2.IngredientStringToId(ip.Ingredient4FID);
            dmc.orderFID = id;
            //dmc.pizzaId = ip.pizzaId;
            dmc.sizeFID = db2.SizeStringToID(ip.sizeFID);
            dmc.totalcost = ip.totalcost;


            //update stock here
            //update order here


            try
            {
                db2.AddPizza(dmc);
                db2.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
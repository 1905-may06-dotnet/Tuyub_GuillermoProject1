using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        public IActionResult Index(int id)
        {
            TempData["userid"] = id;
            TempData.Keep("userid");
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
        List<ViewModels.IndivPizza_Size_Crust_Ingredients> biglist = new List<ViewModels.IndivPizza_Size_Crust_Ingredients>();

        //[ValidateAntiForgeryToken]
        //POST:Restaurant/ShowUsersOrders

        public IActionResult ShowUsersOrders()
        {
            var pizzas = db2.getPizzas();
            var ings = db2.getIngredients();
            var crusts = db2.getCrusts();
            var sizes = db2.getSizes();
            var orders = db2.getOrders();

            foreach(var order in orders)
            {

                foreach (var pizza in pizzas)
                {
                    ViewModels.IndivPizza_Size_Crust_Ingredients ISCI = new ViewModels.IndivPizza_Size_Crust_Ingredients();

                    if (pizza.orderFID == order.orderid)
                    {
                        foreach (var crust in crusts)
                        {
                            if (crust.crustId == pizza.crustFID)
                            {
                                Models.Crust cr = new Models.Crust();
                                cr.crust1 = crust.crust1;
                                cr.crustId = crust.crustId;
                                cr.totalcost_crust = crust.totalcost_crust;
                                ISCI.crust = cr;
                            }
                        }
                        foreach (var size in sizes)
                        {
                            if (size.sizeId == pizza.sizeFID)
                            {
                                Models.Size sz = new Models.Size();
                                sz.sizeId = size.sizeId;
                                sz.size1 = size.size1;
                                sz.totalcost_size = size.totalcost_size;
                                ISCI.size = sz;
                            }
                        }
                        foreach(var ing in ings)
                        {
                            if (ing.ingId == pizza.Ingredient0FID && pizza.Ingredient0FID != 14)
                                ISCI.ingredients.Add(ing.ingredient+" ");
                            if (ing.ingId == pizza.Ingredient1FID && pizza.Ingredient1FID != 14)
                                ISCI.ingredients.Add(ing.ingredient+" ");
                            if (ing.ingId == pizza.Ingredient0FID && pizza.Ingredient2FID != 14)
                                ISCI.ingredients.Add(ing.ingredient+" ");
                            if (ing.ingId == pizza.Ingredient3FID && pizza.Ingredient3FID != 14)
                                ISCI.ingredients.Add(ing.ingredient+" ");
                            if (ing.ingId == pizza.Ingredient4FID && pizza.Ingredient4FID != 14)
                                ISCI.ingredients.Add(ing.ingredient+" ");

                        }

                        Models.Orderpizza y = new Models.Orderpizza();
                        y.locationfid_op = order.locationfid_op;
                        y.orderid = order.orderid;
                        y.userFID = order.userFID;
                        y.Timecheck = order.Timecheck;
                        y.Timecheckdefault = order.Timecheckdefault;
                        if (y.locationfid_op == Int32.Parse(TempData["id"].ToString()))
                        {
                            TempData.Keep("id");
                            ISCI.order = y;
                        }
                        ISCI.totalcost = pizza.totalcost;
                        biglist.Add(ISCI);
                    }
                }
            }

            return View(biglist);



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
            dmc.locationfid_op = Int32.Parse(TempData["id"].ToString());
            dmc.userFID = Int32.Parse(TempData["userid"].ToString());
            dmc.Timecheck = op.Timecheckdefault;
            //dmc.Timecheckdefault = op.Timecheckdefault;
            TempData.Keep("userId");
            TempData.Keep("id");
            try
            {
                if (TempData["userid"] != null)
                {

                    db2.AddOrder(dmc);
                    db2.Save();
                    TempData.Keep("userId");
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData.Keep();
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Pizzabuilder()
        {
            ViewModels.PizzaStrings ip2 = new ViewModels.PizzaStrings();
            return View(ip2);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pizzabuilder(IFormCollection collection, ViewModels.PizzaStrings ip2, int? id)
        {            
           
            Domain.Indiv_pizza dmc = new Domain.Indiv_pizza();
                
            dmc.count = ip2.ip.count;
            dmc.crustFID = db2.CrustStringToID(ip2.crustFID);
            dmc.Ingredient0FID = db2.IngredientStringToId(ip2.ing0); //a string is sent... needs to be converted to id
            dmc.Ingredient1FID = db2.IngredientStringToId(ip2.ing1);
            dmc.Ingredient2FID = db2.IngredientStringToId(ip2.ing2);
            dmc.Ingredient3FID = db2.IngredientStringToId(ip2.ing3);
            dmc.Ingredient4FID = db2.IngredientStringToId(ip2.ing4);
            dmc.orderFID = db2.getNextOrderId();
            if(id!=null)
                TempData["id"] = id;    
            dmc.pizzaId = ip2.ip.pizzaId;
            dmc.sizeFID = db2.SizeStringToID(ip2.sizeFID);
            dmc.totalcost = (db2.getIngredientsById(dmc.Ingredient0FID).cost_ing +
                db2.getIngredientsById(dmc.Ingredient1FID).cost_ing +
                db2.getIngredientsById(dmc.Ingredient2FID).cost_ing +
                db2.getIngredientsById(dmc.Ingredient3FID).cost_ing +
                db2.getIngredientsById(dmc.Ingredient4FID).cost_ing +
                db2.getCrustById(dmc.crustFID).totalcost_crust +
                db2.getSizeById(dmc.sizeFID).totalcost_size)*ip2.ip.count;
            TempData.Keep("id");
            if (dmc.totalcost > 5000 || ip2.ip.count > 100)
            {
                //ought to have message saying cost is over 5000.
                return View();
            }
            IEnumerable<Inventory>  inv = db2.getInventory();
            foreach(var i in inv)
            {
                if (i.resfId == Int32.Parse(TempData["id"].ToString()) && ((i.FkIngredient == dmc.Ingredient0FID && dmc.Ingredient0FID!= 14) || (i.FkIngredient == dmc.Ingredient1FID && dmc.Ingredient1FID!=14) || (i.FkIngredient == dmc.Ingredient2FID&& dmc.Ingredient2FID !=14) || (i.FkIngredient == dmc.Ingredient3FID && dmc.Ingredient3FID !=14) || (i.FkIngredient == dmc.Ingredient4FID &&dmc.Ingredient4FID !=14)))
                {
                    i.stock = i.stock - ip2.ip.count;
                    db2.UpdateStock(i);
                    TempData.Keep("id");
                }
            }   

            //still need to update order ... this will have its own view
            try
            {
                db2.AddPizza(dmc);
                db2.Save();
                return RedirectToAction("OrderPizza");
            }
            catch
            {
                return View();
            }
        }

        Models.Inventory x;
        List<Models.Inventory> invlist = new List<Models.Inventory>();

        public IActionResult Inventory(int id)
        {
            var invs = db2.getInventory();
            foreach (var inv in invs)
            {
                x = new Models.Inventory();
                x.cost_inv = inv.cost_inv;
                x.FkIngredient = inv.FkIngredient;
                x.invId = inv.invId;
                x.resfId = inv.resfId;
                x.stock = inv.stock;
                if(id == x.resfId)
                    invlist.Add(x);
            }
            return View(invlist);

        }

    }
}
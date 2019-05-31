using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWebApp.Models
{
    public class PizzaLogic
    {
        public class Crust
        {
            //crust
            public int crustId { get; set; }
            [DisplayName("Crust")]
            public string crust1 { get; set; }

            [DisplayName("Price")]
            public decimal? totalcost_crust { get; set; }
        }
        public class Size
        {//size
            public int sizeId { get; set; }
            [DisplayName("Size")]
            public string size1 { get; set; }
            [DisplayName("Price")]
            public decimal? totalcost_size { get; set; }
        }
        public class Inventory
        {//inventory
            public int invId { get; set; }
            public int? resfId { get; set; }
            public int? FkIngredient { get; set; }
            [DisplayName("Price")]
            public decimal? cost_inv { get; set; }
            public int? stock { get; set; }
        }
        public class Ingredients
        {
            //ingredients
            public int ingId { get; set; }
            [DisplayName("Topping")]
            public string ingredient { get; set; }
            [DisplayName("Price")]
            public decimal? cost_ing { get; set; }
        }
        public class Indiv_pizza
        {
            //indiv pizza
            [DisplayName("PizzaId")]
            public int pizzaId { get; set; }
            [DisplayName("Topping 1")]
            public int? Ingredient0FID { get; set; }
            [DisplayName("Topping 2")]
            public int? Ingredient1FID { get; set; }
            [DisplayName("Topping 3")]
            public int? Ingredient2FID { get; set; }
            [DisplayName("Topping 4")]
            public int? Ingredient3FID { get; set; }
            [DisplayName("Topping 5")]
            public int? Ingredient4FID { get; set; }
            public int? crustFID { get; set; }
            public int? sizeFID { get; set; }
            public int? count { get; set; }
            public int? orderFID { get; set; }
            [DisplayName("Total Cost")]
            public decimal? totalcost { get; set; }
        }
        public class Orderpizza
        {
            //order pizza
            [DisplayName("Order Id")]
            public int orderid { get; set; }
            public int? locationfid_op { get; set; }
            public int? userFID { get; set; }
            public DateTime? Timecheck { get; set; }
            public DateTime? Timecheckdefault { get; set; }
        }

    }
}

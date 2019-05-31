﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaWebApp.Models
{
    public class ResLocation
    {
        [DisplayName("#")]
        public int LocationId { get; set; } = 1;
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ResName { get; set; }

    }
}

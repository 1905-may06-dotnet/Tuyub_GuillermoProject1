using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApp.Models
{
    public class UserInfo
    {
        //data annotations - UI appearance of fields
            //use to validate input data
            //with EF code first, manage types of the entities
        [DisplayName("#")]//displayname?
        public int Num { get; set; } = 1;
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Phone")]
        public int? Phonenumber { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        //[DataType(DataType.EmailAddress)

    }
}

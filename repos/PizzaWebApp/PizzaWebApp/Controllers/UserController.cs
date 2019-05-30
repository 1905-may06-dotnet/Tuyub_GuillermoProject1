using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace PizzaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInfoRepo db;
        public UserController(IUserInfoRepo db)
        {
            this.db = db;
        }
        Models.UserInfo u;
        List<Models.UserInfo> userlist = new List<Models.UserInfo>();

        public IActionResult Index()
        {
            var users = db.getUsers();
            foreach (var user in users)
            {
                u = new Models.UserInfo();
                u.Name = user.GetName(user.firstname,user.lastname);
                u.Phonenumber = user.phonenumber;
                u.Num = user.userId;
                u.Username = user.username;
                userlist.Add(u);
            }
            return View(userlist);

        }

    }
}
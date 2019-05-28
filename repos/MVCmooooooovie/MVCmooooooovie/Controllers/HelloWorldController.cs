using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCmooooooovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        public string Math(int num1 = 1, int num2 = 2)
        {
            return HtmlEncoder.Default.Encode($"{num1 + num2}");
        }
    }
}
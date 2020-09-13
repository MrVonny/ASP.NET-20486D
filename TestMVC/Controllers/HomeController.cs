using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {

        private IMyService myClass;

        public IActionResult Index()
        {
            return Content(myClass.Write()+ "\n" + myClass.Write());

        }

        public HomeController(IMyService myClass)
        {
            this.myClass = myClass;
        }




    }
}

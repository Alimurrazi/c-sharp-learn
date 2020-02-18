using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Models;

namespace RealTimeChatApp.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit(User user) {
            Console.WriteLine(user);
            return View();
        }

    }
}
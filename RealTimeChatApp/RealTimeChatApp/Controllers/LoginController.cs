using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Models;
using RealTimeChatApp.Services;

namespace RealTimeChatApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ChatService _chatService;
        public LoginController(ChatService chatService)
        {
            _chatService = chatService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult submit(User user)
        {
            var MatchedUser = _chatService.GetUserByInfo(user);
            if (MatchedUser == null)
            {
                ViewBag.NotValidUser = user;
                return View("Index");
            }
            else
            {
                return View("../Dashboard/Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeChatApp.Models;
using RealTimeChatApp.Services;

namespace RealTimeChatApp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ChatService _chatService;
        public SignUpController(ChatService chatService)
        {
            _chatService = chatService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Submit(User user) {
            Console.WriteLine(_chatService.GetUser());
            _chatService.AddUser(user);
            return View();
        }

    }
}
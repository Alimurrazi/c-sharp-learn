using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;
using Microsoft.AspNetCore.SignalR;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.HubConfig;
using Supermarket.API.TimerFeatures;
namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ChatController: ControllerBase
    {
        private IHubContext<ChatHub> _hub;

        public ChatController(IHubContext<ChatHub> hub){
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get(){
            var timerManger = new TimerManager(()=>
                _hub.Clients.All.SendAsync("transferChatData", chatDataManager.GetData()));
            return Ok(new {Message="Request Completed"});
        }
    }
}
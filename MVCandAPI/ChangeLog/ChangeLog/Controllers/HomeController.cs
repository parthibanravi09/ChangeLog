using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChangeLog.Model.User;
using ChangeLog.Models;
using ChangeLog.Service.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChangeLogService _changeLogService;

        public HomeController(IChangeLogService changeLogService)
        {
            _changeLogService = changeLogService;
        }

        public IActionResult Index(string returnUrl)
        {
            var logList = _changeLogService.Get();

            var HomeViewModel = new HomeViewModel()
            {
                PageHeader = "Change Logs",
                ChangeLogModels = logList
            };

            return View(HomeViewModel);
        }

        
        
    }
}

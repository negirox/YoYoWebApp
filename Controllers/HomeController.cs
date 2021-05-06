using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoYo_Web_App.Models;
using YoYo_Web_App.Services;
using YoYo_Web_App.ViewModel;

namespace YoYo_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //creating refrenece of service
        private IPlayerService _playerService;
        public HomeController(ILogger<HomeController> logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;//injecting service 

        }
        /// <summary>
        /// Adding all players login in index method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            List<Player> allPlayers = _playerService.GetPlayers();
            homeViewModel.players = allPlayers;
            return View(homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

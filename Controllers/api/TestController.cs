using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YoYo_Web_App.Models;
using YoYo_Web_App.Services;
using YoYo_Web_App.ViewModel;

namespace YoYo_Web_App.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        /// <summary>
        /// Adding service globally
        /// </summary>
        private IPlayerService _playerService;

        public TestController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlayers")]
        public ActionResult GetPlayers()
        {
            return Ok(_playerService.GetPlayers());
        }

        /// <summary>
        /// Get all players fitness rating
        /// </summary>
        /// <returns></returns>
        [HttpGet("FitnessRating")]
        public ActionResult GetFitnessRating()
        {
            var fitnessRatingData = new List<FitnessRating>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"json\\fitnessrating_beeptest.json"}");
            var jsonText = System.IO.File.ReadAllText(folderDetails);

            JArray jsonArray = JArray.Parse(jsonText);
            foreach (var item in jsonArray)
            {
                var jsonObj = JsonConvert.DeserializeObject<FitnessRating>(item.ToString());
                fitnessRatingData.Add(jsonObj);
            }

            return Ok(fitnessRatingData);
        }

        /// <summary>
        /// Warn player during test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("WarnPlayer/{id}")]
        public ActionResult WarnPlayer(int id)
        {
            var allPlayers = _playerService.GetPlayers();
            try
            {
                int editIndex = allPlayers.FindIndex(o => o.id == id);
                allPlayers[editIndex].warn = true;
                return Ok(allPlayers[editIndex]);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        /// <summary>
        /// show result of user
        /// </summary>
        /// <param name="playerResultRecieved"></param>
        /// <returns></returns>
        [HttpPost("ResultPlayer/{id}")]
        public ActionResult ResultPlayer([FromForm]PlayerResultViewModel playerResultRecieved)
        {
            var playerResult = _playerService.resultPlayer(playerResultRecieved.id, playerResultRecieved.result);
            Console.WriteLine(playerResultRecieved.id + " : " + playerResultRecieved.result);
            return Ok(playerResult);
        }


    }
}
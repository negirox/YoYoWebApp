using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using YoYo_Web_App.Models;
using YoYo_Web_App.ViewModel;

namespace YoYo_Web_App.Services
{
    public class PlayerService : IPlayerService
    {
        /// <summary>
        /// Get all players name
        /// </summary>
        /// <returns></returns>
        public List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            string folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"json\\players.json"}");
            string playerNames = File.ReadAllText(folderDetails);
            JArray jsonArray = JArray.Parse(playerNames);
            foreach (var item in jsonArray)
            {
                Player playerObj = JsonConvert.DeserializeObject<Player>(item.ToString());
                players.Add(playerObj);
            }
            return players;
        }

        /// <summary>
        /// Get player result
        /// </summary>
        /// <param name="playerId">player id to identify player</param>
        /// <param name="result">result of player</param>
        /// <returns></returns>
        public PlayerResultViewModel resultPlayer(int playerId, string result)
        {
            var playerResult = new PlayerResultViewModel();
            var playersList = GetPlayers();
            int editIndex = playersList.FindIndex(o => o.id == playerId);
            playerResult.id = playersList[editIndex].id;
            playerResult.result = result;
            //save data db if you want..

            return playerResult;
        }

        /// <summary>
        /// Warn player during test
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public Player warnPlayer(int playerId)
        {
            var playersList = GetPlayers();
            int editIndex = playersList.FindIndex(o => o.id == playerId);
            playersList[editIndex].warn = true;
            //save data db if you want..

            return playersList[editIndex];
        }
    }
}

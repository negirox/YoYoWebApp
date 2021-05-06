using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYo_Web_App.Models;
using YoYo_Web_App.ViewModel;

namespace YoYo_Web_App.Services
{
    /// <summary>
    /// Players Method
    /// </summary>
    public interface IPlayerService
    {
        List<Player> GetPlayers();
        Player warnPlayer(int playerId);
        PlayerResultViewModel resultPlayer(int playerId, string result);
    }
}

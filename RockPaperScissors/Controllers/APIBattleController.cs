using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockPaperScissorsApplication.Interfaces;
using RockPaperScissorsApplication.ViewModels;

namespace RockPaperScissorsAPI.Controllers
{
    [Route("api/battle")]
    [ApiController]
    public class APIBattleController : ControllerBase
    {
        private readonly IApplicationBattle _appBattle;

        public APIBattleController(IApplicationBattle appBattle)
        {
            _appBattle = appBattle;
        }

        [Route("winner")]
        public string ReturnWinnerBattle([FromBody] BattleViewModel battle)
        {

            PlayerViewModel p = _appBattle.ReturnWinnerBattle(battle);
            //serializa o vencedor e retorna como string
            string winner = JsonConvert.SerializeObject(p, Formatting.Indented);

            return winner;
        }

    }
}
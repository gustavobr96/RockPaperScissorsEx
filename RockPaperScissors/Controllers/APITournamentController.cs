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
    [Route("api/tournament")]
    [ApiController]
    public class APITournamentController : ControllerBase
    {
        private readonly IApplicationTournament _appTournament;

        public APITournamentController(IApplicationTournament appTournament)
        {
            _appTournament = appTournament;
        }

        [HttpPost]
        [Route("winner")]
        public string ReturnWinnerTournament([FromBody] List<BattleViewModel> tournaments)
        {
            PlayerViewModel p = _appTournament.ReturnWinnerTournament(tournaments);
            //serializa o vencedor e retorna como string
             string winner = JsonConvert.SerializeObject(p, Formatting.Indented);

            return winner;
        }
    }
}
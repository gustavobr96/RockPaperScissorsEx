using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RockPaperScissorsSite.Models;

namespace RockPaperScissorsSite.Controlers
{
 
    public class TournamentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("battletournament")]
        [HttpPost]
        public JsonResult BattleWinner([FromBody] List<Battle> tournament)
        {
            string url = "https://localhost:44329/api/tournament/winner";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(tournament), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Player p = JsonConvert.DeserializeObject<Player>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(p, jsettings);
            }


        }
    }
}
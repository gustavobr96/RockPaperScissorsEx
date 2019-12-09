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
 
    public class BattleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("battle")]
        [HttpPost]
        public JsonResult BattleWinner([FromBody] Battle battle)
        {
            string url = "https://localhost:44329/api/battle/winner";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(battle), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Player p = JsonConvert.DeserializeObject<Player>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(p, jsettings);
            }


        }
    }
}
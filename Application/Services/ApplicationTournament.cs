using RockPaperScissorsApplication.Interfaces;
using RockPaperScissorsApplication.ViewModels;
using RockPaperScissorsDomain.Entities;
using RockPaperScissorsDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsApplication.Services
{
   public class ApplicationTournament : IApplicationTournament
    {
        private readonly IServiceTournament _serviceTournament;

        public ApplicationTournament(IServiceTournament serviceTournament)
        {
            _serviceTournament = serviceTournament;
        }

        public PlayerViewModel ReturnWinnerTournament(List<BattleViewModel> tournaments)
        {
            List<Battle> battles = new List<Battle>();
            Battle battle;
            Player player1, player2,player;
            PlayerViewModel pv;

            foreach(var item in tournaments)
            {
                player1 = new Player();
                player1.Name = item.Player1.Name;
                player1.Movement = item.Player1.Movement;

                player2 = new Player();
                player2.Name = item.Player2.Name;
                player2.Movement = item.Player2.Movement;

                battle = new Battle();
                battle.Player1 = player1;
                battle.Player2 = player2;
                battles.Add(battle);

            }

            player = _serviceTournament.ReturnWinnerTournament(battles);
            pv = new PlayerViewModel()
            {
                Name = player.Name,
                Movement = player.Movement
      
            };

            return pv;

        }
    }
}

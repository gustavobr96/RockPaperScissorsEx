using RockPaperScissorsApplication.Interfaces;
using RockPaperScissorsApplication.ViewModels;
using RockPaperScissorsDomain.Entities;
using RockPaperScissorsDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsApplication.Services
{
    public class ApplicationBattle : IApplicationBattle
    {
        private readonly IServiceBattle _Servicebattle;

        public ApplicationBattle(IServiceBattle Servicebattle)
        {
            _Servicebattle = Servicebattle;
        }


        public PlayerViewModel ReturnWinnerBattle(BattleViewModel battle)
        {
            Battle _battle = new Battle();

            Player player = new Player();

            player.Name = battle.Player1.Name;
            player.Movement = battle.Player1.Movement;

            _battle.Player1 = player;

            player = new Player();
            player.Name = battle.Player2.Name;
            player.Movement = battle.Player2.Movement;

            _battle.Player2 = player;

            player = new Player();
            player = _Servicebattle.ReturnWinnerBattle(_battle);


            PlayerViewModel p = new PlayerViewModel()
            {
                Name = player.Name,
                Movement = player.Movement
            };

            return p;

        }
    }
}

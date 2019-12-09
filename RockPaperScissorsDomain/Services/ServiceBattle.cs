using RockPaperScissorsDomain.Entities;
using RockPaperScissorsDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsDomain.Services
{
    public class ServiceBattle : IServiceBattle
    {
       
        public Player ReturnWinnerBattle(Battle battle)
        {
            if (battle.ValidateBattle())
            {
                return battle.PlayerWinner();
            }
            else
                return null;
          
        }

       
    }
}

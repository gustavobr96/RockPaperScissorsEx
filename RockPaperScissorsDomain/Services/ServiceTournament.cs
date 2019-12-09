using RockPaperScissorsDomain.Entities;
using RockPaperScissorsDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsDomain.Services
{
    public class ServiceTournament : IServiceTournament
    {
        public Player ReturnWinnerTournament(List<Battle> battles)
        {
            Battle battle = new Battle();
            Player player1, player2,playerwinner = null;
            int i = 0;

            if(battles != null)
            {

                for (i = 0; battles.Count >1;)
                {

                    if (battle.Player1 == null) 
                        battle.Player1 = battles[i++].PlayerWinner();
                    else
                    {
                        if (battle.Player2 == null)
                        {
                            battle.Player2 = battles[i].PlayerWinner();
                            battles.RemoveAt(i);
                            battles.RemoveAt(--i);
                            battles.Add(battle);
                            battle = new Battle();

                        }

                    }
                   
                }

                playerwinner = battles[0].PlayerWinner();
                return playerwinner;
            }
            return null;
          
           

        }
    }
}

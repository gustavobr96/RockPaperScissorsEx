using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsDomain.Entities
{
    public class Battle
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Battle()
        {
            Player1 = null;
            Player2 = null;
        }

        public Player PlayerWinner()
        {

            if (Player1.Movement == Player2.Movement)
            {
                return Player1;
            }
            else
            {
                if (Player1.Movement == "S" && Player2.Movement == "R")
                    return Player2;


                if (Player1.Movement == "R" && Player2.Movement == "P")
                    return Player2;

                if (Player1.Movement == "P" && Player2.Movement == "S")
                    return Player2;


                //Caso player2 não vencer retorna player1
                return Player1;


            }


        }

        public bool ValidateBattle()
        {
            if (Player1 == null || Player2 == null)
                return false;

            return true;
        }
    }
}

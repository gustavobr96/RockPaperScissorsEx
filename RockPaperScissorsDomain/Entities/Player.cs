using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsDomain.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public string Movement { get; set; }

        public bool ValidateMovement()
        {
            if (string.IsNullOrEmpty(Movement) || (Movement != "P" && Movement != "R" && Movement != "S"))
                return false;

            return true;
            
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Entities;

namespace RockPaperScissorsDomain.Interfaces
{
    public interface IServiceBattle
    {
        Player ReturnWinnerBattle(Battle battle);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsApplication.ViewModels;

namespace RockPaperScissorsApplication.Interfaces
{
    public interface IApplicationBattle
    {
        PlayerViewModel ReturnWinnerBattle(BattleViewModel battle);
    }
}

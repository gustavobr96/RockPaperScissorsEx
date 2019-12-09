using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Entities;

namespace RockPaperScissorsDomain.Interfaces
{
    public interface IServiceTournament
    {
        Player ReturnWinnerTournament(List<Battle> battles);
    }
}

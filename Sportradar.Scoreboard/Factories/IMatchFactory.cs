using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Factories
{
    internal interface IMatchFactory
    {
        public Match? CreateMatch(string homeTeamName, string guestTeamName);
    }
}

using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Factories
{
    internal interface IMatchFactory
    {
        Match? CreateMatch(string homeTeamName, string guestTeamName);
    }
}

using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Factories
{
    internal sealed class MatchFactory : IMatchFactory
    {
        public Match? CreateMatch(string homeTeamName, string guestTeamName)
        {
            if (string.IsNullOrEmpty(homeTeamName) || string.IsNullOrEmpty(guestTeamName))
            {
                return null;
            }

            DateTime currentTime = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeMilliseconds();
            return new Match
            {
                HomeTeamName = homeTeamName,
                GuestTeamName = guestTeamName,
                HomeTeamScore = 0,
                GuestTeamScore = 0,
                MatchStartTimestampMs = unixTime,
            };
        }
    }
}

using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Services
{
    internal class MatchesSummaryFormatter : IMatchesSummaryFormatter
    {
        public IReadOnlyList<Match> FormatMatches(IEnumerable<Match> matches)
        {
            if (matches == null || !matches.Any())
            {
                return new List<Match>(0);
            }

            return matches
                .OrderByDescending(x => x.HomeTeamScore + x.GuestTeamScore)
                .ThenByDescending(x => x.MatchStartTimestampMs)
                .ToList();
        }
    }
}

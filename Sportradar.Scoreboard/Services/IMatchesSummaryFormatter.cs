using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Services
{
    internal interface IMatchesSummaryFormatter
    {
        IReadOnlyList<Match> FormatMatches(IEnumerable<Match> matches);
    }
}

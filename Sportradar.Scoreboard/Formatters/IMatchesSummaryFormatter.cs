using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Formatters
{
    internal interface IMatchesSummaryFormatter
    {
        IReadOnlyList<Match> FormatMatches(IEnumerable<Match> matches);
    }
}

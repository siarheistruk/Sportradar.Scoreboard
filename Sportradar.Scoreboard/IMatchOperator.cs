using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard
{
    public interface IMatchOperator
    {
        int StartMatch(string homeTeamName, string guestTeamName);
        void UpdateMatch(int id, int homeTeamScore, int guestTeamScore);
        void FinishMatch(int id);
        IReadOnlyList<Match> GetMatchesSummary();
    }
}

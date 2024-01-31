using Sportradar.Scoreboard.Data.Repository;
using Sportradar.Scoreboard.Factories;
using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard
{
    internal sealed class MatchOperator : IMatchOperator
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchFactory _matchFactory;

        public MatchOperator(IMatchRepository matchRepository, IMatchFactory matchFactory)
        {
            _matchRepository = matchRepository;
            _matchFactory = matchFactory;
        }

        public void FinishMatch(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Match> GetMatchesSummary()
        {
            throw new NotImplementedException();
        }

        public int StartMatch(string homeTeamName, string guestTeamName)
        {
            throw new NotImplementedException();
        }

        public void UpdateMatch(int id, int homeTeamScore, int guestTeamScore)
        {
            throw new NotImplementedException();
        }
    }
}

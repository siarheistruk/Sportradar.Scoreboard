using Sportradar.Scoreboard.Data.Dto;
using Sportradar.Scoreboard.Data.Repository;
using Sportradar.Scoreboard.Factories;
using Sportradar.Scoreboard.Formatters;
using Sportradar.Scoreboard.Helpers;
using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard
{
    internal sealed class MatchOperator : IMatchOperator
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMatchFactory _matchFactory;
        private readonly IMatchesSummaryFormatter _matchSummaryFormatter;

        public MatchOperator(IMatchRepository matchRepository, IMatchFactory matchFactory, IMatchesSummaryFormatter matchSummaryFormatter)
        {
            _matchRepository = matchRepository;
            _matchFactory = matchFactory;
            _matchSummaryFormatter = matchSummaryFormatter;
        }

        public void FinishMatch(int id)
        {
            _matchRepository.Delete(id);
        }

        public IReadOnlyList<Match> GetMatchesSummary()
        {
            var matches = _matchRepository.GetAll();
            return _matchSummaryFormatter.FormatMatches(matches.Select(x => x.ToMatch()));
        }

        public int StartMatch(string homeTeamName, string guestTeamName)
        {
            var newMatchModel = _matchFactory.CreateMatch(homeTeamName, guestTeamName);
            if (newMatchModel == null)
            {
                return -1;
            }

            return _matchRepository.Add(newMatchModel.ToMatchDto());
        }

        public void UpdateMatch(int id, int homeTeamScore, int guestTeamScore)
        {
            _matchRepository.Update(new UpdateMatchDto 
            {
                MatchId = id,
                HomeTeamScore = homeTeamScore,
                GuestTeamScore = guestTeamScore 
            });
        }
    }
}

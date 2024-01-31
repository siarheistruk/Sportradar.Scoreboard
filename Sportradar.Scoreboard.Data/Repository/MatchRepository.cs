using Sportradar.Scoreboard.Data.Models;

namespace Sportradar.Scoreboard.Data.Repository
{
    internal sealed class MatchRepository : IMatchRepository
    {
        private readonly List<MatchDto> _matches = new List<MatchDto>();
        private int _currentId;

        public int Add(MatchDto item)
        {
            var matchToAdd = item with { Id = _currentId++ };
            _matches.Add(matchToAdd);

            return matchToAdd.Id;
        }

        public void Delete(int id)
        {
            var matchToRemove = _matches.FirstOrDefault(x => x.Id == id);
            if (matchToRemove != null)
            {
                _matches.Remove(matchToRemove);
            }
        }

        public IReadOnlyList<MatchDto> GetAll()
        {
            return _matches.AsReadOnly();
        }

        public void Update(UpdateMatchDto item)
        {
            var matchToUpdate = _matches.FirstOrDefault(x => x.Id == item.MatchId);
            if (matchToUpdate != null)
            {
                matchToUpdate.HomeTeamScore = item.HomeTeamScore;
                matchToUpdate.GuestTeamScore = item.GuestTeamScore;
            }
        }
    }
}

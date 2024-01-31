using Sportradar.Scoreboard.Data.Dto;

namespace Sportradar.Scoreboard.Data.Repository
{
    public interface IMatchRepository
    {
        int Add(MatchDto item);
        void Delete(int id);
        IReadOnlyList<MatchDto> GetAll();
        void Update(UpdateMatchDto item);
    }
}

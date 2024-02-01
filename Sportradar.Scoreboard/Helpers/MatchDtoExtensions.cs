using Sportradar.Scoreboard.Data.Dto;
using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Helpers
{
    internal static class MatchDtoExtensions
    {
        public static Match ToMatch(this MatchDto matchDto)
        {
            return new Match
            {
                Id = matchDto.Id,
                HomeTeamName = matchDto.HomeTeamName,
                GuestTeamName = matchDto.GuestTeamName,
                HomeTeamScore = matchDto.HomeTeamScore,
                GuestTeamScore = matchDto.GuestTeamScore,
                MatchStartTimestampMs = matchDto.MatchStartTimestampMs,
            };
        }
    }
}

using Sportradar.Scoreboard.Data.Dto;
using Sportradar.Scoreboard.Models;

namespace Sportradar.Scoreboard.Helpers
{
    internal static class MatchExtensions
    {
        public static MatchDto ToMatchDto(this Match match)
        {
            return new MatchDto
            {
                Id = match.Id,
                HomeTeamName = match.HomeTeamName,
                GuestTeamName = match.GuestTeamName,
                HomeTeamScore = match.HomeTeamScore,
                GuestTeamScore = match.GuestTeamScore,
                MatchStartTimestampMs = match.MatchStartTimestampMs,
            };
        }
    }
}

namespace Sportradar.Scoreboard.Data.Models
{
    public record UpdateMatchDto
    {
        public int MatchId { get; init; }
        public int HomeTeamScore { get; init; }
        public int GuestTeamScore { get; init; }
    }
}

namespace Sportradar.Scoreboard.Data.Dto
{
    public sealed record UpdateMatchDto
    {
        public int MatchId { get; init; }
        public int HomeTeamScore { get; init; }
        public int GuestTeamScore { get; init; }
    }
}

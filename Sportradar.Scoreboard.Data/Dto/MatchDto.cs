namespace Sportradar.Scoreboard.Data.Dto
{
    public record MatchDto
    {
        public int Id { get; init; }
        public string HomeTeamName { get; init; } = null!;
        public string GuestTeamName { get; init; } = null!;
        public int HomeTeamScore { get; set; }
        public int GuestTeamScore { get; set; }
        public long MatchStartTimestampMs { get; init; }
    }
}

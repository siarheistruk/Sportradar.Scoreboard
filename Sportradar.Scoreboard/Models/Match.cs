namespace Sportradar.Scoreboard.Models
{
    internal record Match
    {
        public int Id { get; init; }
        public string HomeTeamName { get; init; } = null!;
        public string GuestTeamName { get; init; } = null!;
        public int HomeTeamScore { get; init; }
        public int GuestTeamScore { get; init; }
        public long MatchStartTimestampMs { get; init; }
    }
}

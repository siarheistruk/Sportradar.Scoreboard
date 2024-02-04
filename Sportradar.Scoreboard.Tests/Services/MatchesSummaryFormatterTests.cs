using Sportradar.Scoreboard.Models;
using Sportradar.Scoreboard.Formatters;

namespace Sportradar.Scoreboard.Tests.Services
{
    internal class MatchesSummaryFormatterTests
    {
        [Test]
        public void FormatMatches_InputIsNotEmpty_MatchesFormatted()
        {
            var input = CreateInputTestData();
            var summaryFormatter = new MatchesSummaryFormatter();

            var actual = summaryFormatter.FormatMatches(input);

            Assert.That(actual[0].Id, Is.EqualTo(4));
            Assert.That(actual[1].Id, Is.EqualTo(3));
            Assert.That(actual[2].Id, Is.EqualTo(1));
            Assert.That(actual[3].Id, Is.EqualTo(2));
            Assert.That(actual[4].Id, Is.EqualTo(0));
        }

        [Test]
        public void FormatMatches_InputIsEmpty_ReturnsEmptyResult()
        {
            var summaryFormatter = new MatchesSummaryFormatter();

            var actual = summaryFormatter.FormatMatches(Array.Empty<Match>());

            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void FormatMatches_InputIsNull_ReturnsEmptyResult()
        {
            var summaryFormatter = new MatchesSummaryFormatter();

            var actual = summaryFormatter.FormatMatches(null);

            Assert.That(actual, Is.Empty);
        }

        private IEnumerable<Match> CreateInputTestData()
        {
            return new[]
            {
                new Match
                {
                    Id = 0,
                    HomeTeamName = "Team0",
                    GuestTeamName = "Team1",
                    HomeTeamScore = 1,
                    GuestTeamScore = 1,
                    MatchStartTimestampMs = 50000,
                },
                new Match
                {
                    Id = 1,
                    HomeTeamName = "Team2",
                    GuestTeamName = "Team3",
                    HomeTeamScore = 2,
                    GuestTeamScore = 2,
                    MatchStartTimestampMs = 200000,
                },
                new Match
                {
                    Id = 2,
                    HomeTeamName = "Team4",
                    GuestTeamName = "Team5",
                    HomeTeamScore = 2,
                    GuestTeamScore = 2,
                    MatchStartTimestampMs = 150000,
                },
                new Match
                {
                    Id = 3,
                    HomeTeamName = "Team6",
                    GuestTeamName = "Team7",
                    HomeTeamScore = 5,
                    GuestTeamScore = 0,
                    MatchStartTimestampMs = 50000,
                },
                new Match
                {
                    Id = 4,
                    HomeTeamName = "Team4",
                    GuestTeamName = "Team1",
                    HomeTeamScore = 8,
                    GuestTeamScore = 2,
                    MatchStartTimestampMs = 700000,
                },
            };
        }
    }
}
